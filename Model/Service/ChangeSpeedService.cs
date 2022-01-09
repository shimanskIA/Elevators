using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Model.Entities;

namespace Model.Service
{
    public class ChangeSpeedService : IChangeSpeedService
    {
        private readonly IRepository<SpeedTiming> _srepository;
        private readonly IRepository<Elevator> _elrepository;
        private readonly IRepository<Human> _repository;
        private readonly IRepository<FixedGenRule> _fg_repository;
        private readonly IRepository<RandomGenRule> _rg_repository;
        private readonly IRepository<int> _prepository;
        static object myObj = new object();

        public ChangeSpeedService(IRepository<SpeedTiming> srepository, IRepository<Elevator> elrepository, IRepository<Human> repository, IRepository<FixedGenRule> fg_repository, IRepository<RandomGenRule> rg_repository, IRepository<int> prepository)
        {
            _srepository = srepository;
            _elrepository = elrepository;
            _repository = repository;
            _fg_repository = fg_repository;
            _rg_repository = rg_repository;
            _prepository = prepository;
        }

        public void ChangeSpeed(double speed)
        {
            IEnumerable<SpeedTiming> timings = _srepository.GetAll();
            IEnumerable<Human> people_list = _repository.GetAll();
            IEnumerable<FixedGenRule> fixed_gen_rule_list = _fg_repository.GetAll();
            IEnumerable<RandomGenRule> random_gen_rule_list = _rg_repository.GetAll();
            IEnumerable<int> parameters = _prepository.GetAll();
            for (int i = 0; i < timings.Count(); i++)
            {
                if (timings.ElementAt(i).activated == true)
                {
                    timings.ElementAt(i).activated = false;
                    timings.ElementAt(i).activated_time = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13) - timings.ElementAt(i).activation_time;
                    for (int j = 0; j < people_list.Count(); j++)
                    {
                        people_list.ElementAt(j).time_before_change += (int)(((DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13) - people_list.ElementAt(j).generation_time) * timings.ElementAt(i).speed);
                        people_list.ElementAt(j).generation_time = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13);
                    }
                    break;
                }
            }
            
            for (int i = 0; i < timings.Count(); i++)
            {
                if (timings.ElementAt(i).speed == speed)
                {
                    timings.ElementAt(i).activation_time = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13);
                    timings.ElementAt(i).activated = true;
                    break;
                }
            }

            for (int i = 0; i < fixed_gen_rule_list.Count(); i++)
            {
                fixed_gen_rule_list.ElementAt(i).multiplicated = true;
            }

            for (int i = 0; i < random_gen_rule_list.Count(); i++)
            {
                random_gen_rule_list.ElementAt(i).multiplicated = true;
            }
            Monitor.Enter(myObj);
            try
            {
                _prepository.Update(19, 1);
            }
            finally
            {
                Monitor.Exit(myObj);
            }
        }
    }
}
