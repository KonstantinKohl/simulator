/**
 * Copyright (c) 2019 LG Electronics, Inc.
 *
 * This software contains code licensed as described in LICENSE.
 *
 */

using Mono.Data.Sqlite;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;
using Simulator.Web;
using Simulator.Sensors;
using Simulator.Bridge.Ros;
using Simulator.Bridge.Cyber;

namespace Simulator.Database
{
    public static class DatabaseManager
    {
        static IDatabaseBuildConfiguration DbConfig;

        public static IDatabase Open()
        {
            return DbConfig.Create();
        }

        static string GetDatabasePath()
        {
            return Path.Combine(Application.persistentDataPath, "data.db");
        }

        static string GetBackupPath()
        {
            return Path.Combine(Application.persistentDataPath, "backup.db");
        }

        public static string GetConnectionString()
        {
            return $"Data Source = {GetDatabasePath()};version=3;";
        }

        public static IDatabaseBuildConfiguration GetConfig(string connectionString)
        {
            return DatabaseConfiguration.Build()
                .UsingConnectionString(connectionString)
                .UsingProvider(new Providers.UnityDatabaseProvider())
                .UsingDefaultMapper<ConventionMapper>(m =>
                {
                    // Vehicle => vehicles
                    m.InflectTableName = (inflector, tn) => inflector.Pluralise(inflector.Uncapitalise(tn));

                    // TimeOfDay => timeOfDay
                    m.InflectColumnName = (inflector, cn) => inflector.Uncapitalise(cn);
                });
        }

        public static void Init()
        {
            var connectionString = GetConnectionString();
            DbConfig = GetConfig(connectionString);

            using (var db = new SqliteConnection(connectionString))
            {
                try
                {
                    db.Open();
                }
                catch (SqliteException ex)
                {
                    Debug.LogError(ex);
                    Debug.Log("Cannot open database, removing it and replacing with backup");
                    try
                    {
                        File.Copy(GetBackupPath(), GetDatabasePath(), true);
                        db.Open();
                    }
                    catch (Exception backupEx)
                    {
                        Debug.LogError(backupEx);
                        Debug.Log("Cannot open backup, deleting");
                        File.Delete(GetDatabasePath());
                        File.Delete(GetBackupPath());
                        db.Open();
                    }
                }

                CheckForPatches();
            }

            File.Copy(GetDatabasePath(), GetBackupPath(), true);
        }

        static void CheckForPatches()
        {
            using (var connection = new SqliteConnection(GetConnectionString()))
            {
                string[] expectedTables = { "maps", "vehicles", "clusters", "simulations" };
                connection.Open();
                if (!TablesExist(expectedTables, connection))
                {
                    var sql = Resources.Load<TextAsset>("Database/simulator");
                    using (var command = new SqliteCommand(sql.text, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    CreateDefaultDbAssets();
                }
                connection.Close();
            }

            long currentVersion;

            using (var connection = new SqliteConnection(GetConnectionString()))
            {
                connection.Open();
                using (var command = new SqliteCommand(connection))
                {
                    command.CommandText = "PRAGMA user_version";
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        currentVersion = reader.GetFieldValue<long>(0);
                    }
                }
                connection.Close();
            }

            Debug.Log($"Current Database Version: {currentVersion}");

            for (long i = currentVersion + 1; ; i++)
            {
                TextAsset patch = Resources.Load<TextAsset>($"Database/Patches/{i}");
                if (patch == null)
                {
                    currentVersion = i - 1;
                    break;
                }

                string version = patch.name;
                Debug.Log($"Applying patch {version} to database...");
                using (var connection = new SqliteConnection(GetConnectionString()))
                {
                    connection.Open();
                    using (var command = new SqliteCommand(connection))
                    {
                        command.CommandText = patch.text;
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }

            using (var connection = new SqliteConnection(GetConnectionString()))
            {
                connection.Open();
                using (var command = new SqliteCommand(connection))
                {
                    command.CommandText = $"PRAGMA user_version = {currentVersion};";
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

            Debug.Log($"Final Database Version: {currentVersion}");
        }

        static void CreateDefaultDbAssets()
        {
            string os;
            if (SystemInfo.operatingSystemFamily == OperatingSystemFamily.Windows)
            {
                os = "windows";
            }
            else if (SystemInfo.operatingSystemFamily == OperatingSystemFamily.Linux)
            {
                os = "linux";
            }
            else if (SystemInfo.operatingSystemFamily == OperatingSystemFamily.MacOSX)
            {
                os = "macos";
            }
            else
            {
                return;
            }

            var info = Resources.Load<Utilities.BuildInfo>("BuildInfo");
            if (info == null || info.GitCommit == null || info.DownloadHost == null)
            {
                return;
            }

            using (var db = Open())
            {
                long? defaultMap = null;

                if (info.DownloadEnvironments != null)
                {
                    foreach (var e in info.DownloadEnvironments)
                    {
                        var url = $"https://{info.DownloadHost}/{info.GitCommit}/{os}/environment_{e.ToLowerInvariant()}";
                        var localPath = WebUtilities.GenerateLocalPath("Maps");
                        var map = new MapModel()
                        {
                            Name = e,
                            Status = "Downloading",
                            Url = url,
                            LocalPath = localPath,
                        };

                        var id = db.Insert(map);

                        if (map.Name == "BorregasAve")
                        {
                            defaultMap = map.Id;
                        }
                    }
                }

                long? autowareVehicle = null;
                long? noBridgeVehicle = null;
                long? apolloVehicle = null;

                if (info.DownloadVehicles != null)
                {
                    foreach (var v in info.DownloadVehicles)
                    {
                        var localPath = WebUtilities.GenerateLocalPath("Vehicles");
                        if (v == "Jaguar2015XE")
                        {
                            AddVehicle(db, info, os, v, localPath, DefaultSensors.Autoware, " (Autoware)", new RosBridgeFactory().Name);
                            AddVehicle(db, info, os, v, localPath, DefaultSensors.Apollo30, " (Apollo 3.0)", new RosApolloBridgeFactory().Name);

                            noBridgeVehicle = AddVehicle(db, info, os, v, localPath, DefaultSensors.DataCollection, " (No Bridge)");
                        }
                        else if (v == "Lexus2016RXHybrid")
                        {
                            autowareVehicle = AddVehicle(db, info, os, v, localPath, DefaultSensors.Autoware, " (Autoware)", new RosBridgeFactory().Name);
                        }
                        else if (v == "Lincoln2017MKZ")
                        {
                            apolloVehicle = AddVehicle(db, info, os, v, localPath, DefaultSensors.Apollo50, " (Apollo 5.0)", new CyberBridgeFactory().Name);
                        }
                        else
                        {
                            apolloVehicle = AddVehicle(db, info, os, v, localPath, DefaultSensors.Apollo50, " (Apollo 5.0)", new CyberBridgeFactory().Name);
                        }
                    }
                }

                if (defaultMap.HasValue)
                {
                    var dt = DateTime.Now.Date + new TimeSpan(12, 0, 0);
                    var dtEvening = DateTime.Now.Date + new TimeSpan(17, 20, 0);

                    var sim1 = new SimulationModel()
                    {
                        Name = "BorregasAve, no bridge, data collection",
                        Cluster = 0,
                        Map = defaultMap.Value,
                        ApiOnly = false,
                        Interactive = true,
                        TimeOfDay = dt,
                    };
                    AddSimulation(db, sim1, noBridgeVehicle);

                    var sim2 = new SimulationModel()
                    {
                        Name = "BorregasAve (with Autoware)",
                        Cluster = 0,
                        Map = defaultMap.Value,
                        ApiOnly = false,
                        Interactive = true,
                        TimeOfDay = dt,
                    };
                    AddSimulation(db, sim2, autowareVehicle);

                    var sim3 = new SimulationModel()
                    {
                        Name = "BorregasAve, noninteractive (with Apollo 5.0)",
                        Cluster = 0,
                        Map = defaultMap.Value,
                        ApiOnly = false,
                        Seed = 12345,
                        TimeOfDay = dt,
                        Wetness = 0.4f,
                        Cloudiness = 0.6f,
                        Fog = 0.5f,
                        UseTraffic = true,
                    };
                    AddSimulation(db, sim3, apolloVehicle);

                    var sim4 = new SimulationModel()
                    {
                        Name = "BorregasAve, evening (with Apollo 5.0)",
                        Cluster = 0,
                        Map = defaultMap.Value,
                        ApiOnly = false,
                        Interactive = true,
                        TimeOfDay = dtEvening,
                        UseTraffic = true,
                    };
                    AddSimulation(db, sim4, apolloVehicle);

                    var sim5 = new SimulationModel()
                    {
                        Name = "API Only",
                        Cluster = 0,
                        Map = defaultMap.Value,
                        ApiOnly = true,
                    };
                    db.Insert(sim5);
                }
            }
        }

        static void AddSimulation(IDatabase db, SimulationModel sim, long? vehicle)
        {
            if (!vehicle.HasValue)
            {
                return;
            }

            var id = (long)db.Insert(sim);

            var conn = new ConnectionModel()
            {
                Simulation = id,
                Vehicle = vehicle.Value,
                Connection = "localhost:9090",
            };

            db.Insert(conn);
        }

        static long AddVehicle(IDatabase db, Utilities.BuildInfo info, string os, string name, string localPath, string sensors, string suffix = null, string bridge = null)
        {
            var url = $"https://{info.DownloadHost}/{info.GitCommit}/{os}/vehicle_{name.ToLowerInvariant()}";
            var vehicle = new VehicleModel()
            {
                Name = name + (suffix == null ? string.Empty : suffix),
                Status = "Downloading",
                Url = url,
                LocalPath = localPath,
                BridgeType = bridge,
                Sensors = sensors,
            };
            db.Insert(vehicle);

            return vehicle.Id;
        }

        public static IEnumerable<MapModel> PendingMapDownloads()
        {
            using (var db = Open())
            {
                var sql = Sql.Builder.From("maps").Where("status = @0", "Downloading");
                return db.Query<MapModel>(sql);
            }
        }

        public static IEnumerable<VehicleModel> PendingVehicleDownloads()
        {
            using (var db = Open())
            {
                var sql = Sql.Builder.From("vehicles").Where("status = @0", "Downloading");
                return db.Query<VehicleModel>(sql);
            }
        }

        public static bool TablesExist(string[] tableNames, SqliteConnection connection)
        {
            for (int i = 0; i < tableNames.Length; i++)
            {
                if (!TableExists(tableNames[i], connection)) return false;
            }
            return true;
        }

        public static bool TableExists(string tableName, SqliteConnection connection)
        {
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM sqlite_master WHERE type = 'table' AND name = @name";
                cmd.Parameters.Add("@name", DbType.String).Value = tableName;
                return cmd.ExecuteScalar() != null;
            }
        }
    }
}