/**
 * Copyright (c) 2019 LG Electronics, Inc.
 *
 * This software contains code licensed as described in LICENSE.
 *
 */

using PetaPoco;
using System.Collections.Generic;

namespace Simulator.Database.Services
{
    public class ClusterService : IClusterService
    {
        public IEnumerable<ClusterModel> List(int page, int count, string owner)
        {
            using (var db = DatabaseManager.Open())
            {
                var sql = Sql.Builder.Where("owner = @0 OR owner IS NULL", owner);
                return db.Page<ClusterModel>(page, count, sql).Items;
            }
        }

        public bool Validate(long id, string owner)
        {
            using (var db = DatabaseManager.Open())
            {
                var sql = Sql.Builder.Where("owner = @0 OR owner IS NULL", owner);
                return db.SingleOrDefault<ClusterModel>(sql) != null;
            }
        }

        public ClusterModel Get(long id, string owner)
        {
            using (var db = DatabaseManager.Open())
            {
                var sql = Sql.Builder.Where("id = @0", id).Where("owner = @0 OR owner IS NULL", owner);
                return db.Single<ClusterModel>(sql);
            }
        }

        public long Add(ClusterModel cluster)
        {
            using (var db = DatabaseManager.Open())
            {
                return (long)db.Insert(cluster);
            }
        }

        public int Update(ClusterModel cluster)
        {
            using (var db = DatabaseManager.Open())
            {
                return db.Update(cluster);
            }
        }

        public int Delete(long id, string owner)
        {
            using (var db = DatabaseManager.Open())
            {
                var sql = Sql.Builder.Where("id = @0", id).Where("owner = @0 OR owner IS NULL", owner);
                return db.Delete<ClusterModel>(sql);
            }
        }
    }
}
