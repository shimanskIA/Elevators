using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Model;
using System.IO;
using Model.Entities;
using System.Threading;

namespace Presentation
{
    public class SimulationPresenter
    {
        private readonly IKernel _kernel;
        private readonly ISimulationView _view;
        private readonly ISimulationService _service;

        public SimulationPresenter(IKernel kernel, ISimulationView view, ISimulationService service)
        {
            _kernel = kernel;

            _view = view;
            _view.GoToCreatePeopleForm += ShowCreatePeopleView;
            _view.GoToSetRuleForm += ShowSetRuleForm;
            _view.GetPeopleStatus += GetPeopleStatus;
            _view.GoToDeleteRuleForm += ShowDeleteRuleForm;
            _view.FireAlarmActivate += FireAlarmActivate;
            _view.FireAlarmDeactivate += FireAlarmDeactivate;
            _view.GoToChangeSpeedForm += ShowChangeSpeedView;
            _view.PauseActivate += ActivatePause;
            _view.Stop += Stop;
            _view.Print += Print;
            _service = service;
        }

        private void GetPeopleStatus()
        {
            IEnumerable<Human> list = _service.GetPeopleStatus();
            for (int i = 0; i < list.Count(); i++)
            {
                if (i == 0)
                {
                    _view.FillTheGrid(list.ElementAt(i).name, list.ElementAt(i).Id, list.ElementAt(i).generation_stage, list.ElementAt(i).aim_stage, list.ElementAt(i).waiting_time, list.ElementAt(i).in_elevator, list.ElementAt(i).reached_stage, true);
                }
                else
                {
                    _view.FillTheGrid(list.ElementAt(i).name, list.ElementAt(i).Id, list.ElementAt(i).generation_stage, list.ElementAt(i).aim_stage, list.ElementAt(i).waiting_time, list.ElementAt(i).in_elevator, list.ElementAt(i).reached_stage, false);
                }
            }
            if (list.Count() == 0)
            {
                _view.ClearTheGrid();
            }
        }

        private void FireAlarmActivate()
        {
            _service.FireAlarmActivate();
            _view.FA_Activator();
        }

        private void FireAlarmDeactivate()
        {
            _service.FireAlarmDeactivate();
            _view.FA_Deactivator();
        }

        private void ActivatePause()
        {
            _service.ActivatePause();
        }

        private void ShowCreatePeopleView()
        {
            _kernel.Get<CreatePeoplePresenter>().Run();
        }

        private void ShowSetRuleForm()
        {
            _kernel.Get<RulePresenter>().Run();
        }

        private void ShowDeleteRuleForm()
        {
            _kernel.Get<DeleteRulePresenter>().Run();
        }

        private void ShowChangeSpeedView()
        {
            _kernel.Get<ChangeSpeedPresenter>().Run();
        }

        private void Print()
        {
            _view.ClearTheRows();
            int count = _service.GetElevatorsCount();
            List<int> el_stats = new List<int>();
            for (int i = 0; i < count; i++)
            {
                el_stats = _service.GetElevatorsInfos(i);
                _view.FillTheElevatorsTable(el_stats[0], el_stats[1], el_stats[2]);
            }
            List<int> status_bar = new List<int>();
            status_bar = _service.GetStatusInfos();
            _view.FillTheStatusBar(status_bar[0], status_bar[1], status_bar[2]);
        }

        private void Stop()
        {
            bool stop;
            stop = _service.StopThreads();
            if (stop == true)
            {
                _view.Close();
                _kernel.Get<StatsPresenter>().Run();
            }
        }

        public void Run()
        {
            _view.Show();
            _service.StartSimulation();
        }
    }
}
