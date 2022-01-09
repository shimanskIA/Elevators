using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace Model.Service
{
    public class StatsService : IStatsService
    {
        private readonly IRepository<Elevator> _elrepository;
        private readonly IRepository<int> _prepository;
        public StatsService(IRepository<Elevator> elrepository, IRepository<int> prepository)
        {
            _elrepository = elrepository;
            _prepository = prepository;
        }

        public int GetElevatorsCount()
        {
            IEnumerable<Elevator> elevator_list = _elrepository.GetAll();
            return elevator_list.Count();
        }

        public List<int> GetElevatorInfo(int number)
        {
            List<int> el_stats = new List<int>();
            IEnumerable<Elevator> elevator_list = _elrepository.GetAll();
            for (int i = 0; i < elevator_list.Count(); i++)
            {
                if (i == number)
                {
                    el_stats.Add(elevator_list.ElementAt(i).Id);
                    el_stats.Add(elevator_list.ElementAt(i).transported_people);
                    el_stats.Add(elevator_list.ElementAt(i).rides);
                    el_stats.Add(elevator_list.ElementAt(i).empty_rides);
                    break;
                }
            }
            return el_stats;
        }

        public List<int> GetSimulationStats()
        {
            List<int> el_stats = new List<int>();
            IEnumerable<int> parameters = _prepository.GetAll();
            IEnumerable<Elevator> elevator_list = _elrepository.GetAll();
            int amount = 0;
            el_stats.Add(0);
            for (int i = 0; i < elevator_list.Count(); i++)
            {
                el_stats[0] += elevator_list.ElementAt(i).rides;
                amount += elevator_list.ElementAt(i).transported_people;
            }
            if (amount == 0)
            {
                el_stats.Add(0);
            }
            else
            {
                el_stats.Add((int)(parameters.ElementAt(14) / (amount * 1000)));
            }
            el_stats.Add((int)(parameters.ElementAt(15) / 1000));
            el_stats.Add((int)(parameters.ElementAt(14) / 1000));
            el_stats.Add(parameters.ElementAt(16));
            el_stats.Add((int)(parameters.ElementAt(17) / 1000));
            return el_stats;
        }
    }
}
