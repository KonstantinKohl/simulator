/**
 * Copyright (c) 2019 LG Electronics, Inc.
 *
 * This software contains code licensed as described in LICENSE.
 *
 */

using System.Collections.Generic;

namespace Simulator.Database.Services
{
    public interface ISimulationService
    {
        IEnumerable<SimulationModel> List(int page, int count, string owner);
        SimulationModel Get(long id, string owner);
        long Add(SimulationModel simulation);
        int Update(SimulationModel simulation);
        int Delete(long id, string owner);

        string GetActualStatus(SimulationModel simulation, bool allowDownloading);
        SimulationModel GetCurrent(string owner);
        void Start(SimulationModel simulation);
        void Stop();
    }
}
