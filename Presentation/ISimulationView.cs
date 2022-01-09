using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public interface ISimulationView : IView
    {
        event Action GoToCreatePeopleForm;
        event Action GetPeopleStatus;
        event Action GoToSetRuleForm;
        event Action GoToDeleteRuleForm;
        event Action GoToChangeSpeedForm;
        event Action FireAlarmActivate;
        event Action FireAlarmDeactivate;
        event Action PauseActivate;
        event Action Stop;
        event Action Print;

        void FillTheGrid(string name, int id, int gstage, int astage, double time, bool in_elevator, bool reached, bool new_it);
        void FA_Activator();
        void FA_Deactivator();
        void ClearTheGrid();
        void ClearTheRows();
        void FillTheStatusBar(int minutes, int seconds, int people);
        void FillTheElevatorsTable(int id, int people_inside, int actual_stage);
        //void ShowError(string message);
    }
}
