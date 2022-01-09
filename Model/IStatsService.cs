﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Service
{
    public interface IStatsService
    {
        int GetElevatorsCount();
        List<int> GetElevatorInfo(int count);
        List<int> GetSimulationStats();
    }
}
