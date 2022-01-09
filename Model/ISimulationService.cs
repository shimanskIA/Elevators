using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace Model
{
    public interface ISimulationService
    {
        IEnumerable<Human> GetPeopleStatus();
        void FireAlarmActivate();
        void FireAlarmDeactivate();
        void ActivatePause();
        bool StopThreads();
        void StartSimulation();
        int GetElevatorsCount();
        List<int> GetElevatorsInfos(int i);
        List<int> GetStatusInfos();
    }
}
