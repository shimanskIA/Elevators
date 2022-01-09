using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Model.Service;

namespace Presentation
{
    public class StatsPresenter
    {
        private readonly IKernel _kernel;
        private readonly IStatsView _view;
        private readonly IStatsService _service;

        public StatsPresenter(IKernel kernel, IStatsView view, IStatsService service)
        {
            _kernel = kernel;

            _view = view;

            _service = service;
        }

        public void Run()
        {
            int el_count;
            List<int> el_stats;
            el_count = _service.GetElevatorsCount();
            for (int i = 0; i < el_count; i++)
            {
                el_stats = _service.GetElevatorInfo(i);
                _view.FillTheElevatorsGrid(el_stats[0], el_stats[1], el_stats[2], el_stats[3]);
            }
            el_stats = _service.GetSimulationStats();
            _view.FillTheInfosGrid(el_stats[0], el_stats[1], el_stats[2], el_stats[3], el_stats[4], el_stats[5]);
            _view.Show();
        }
    }
}
