using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace Model.Service
{
    public class PeopleService : IPeopleService
    {
        private readonly IRepository<Human> _repository;
        private readonly IRepository<int> _prepository;
        public PeopleService(IRepository<Human> repository, IRepository<int> prepository)
        {
            _repository = repository;
            _prepository = prepository;
        }
       
        public void GeneratePeople(string p1, string p2, string p3, string p4)
        {
            int amount = int.Parse(p1);
            int gstage = int.Parse(p2);
            int astage = int.Parse(p3);
            int average_weight = int.Parse(p4);
            IEnumerable<int> parameters = _prepository.GetAll();
            for (int i = 0; i < amount; i++)
            {
                _repository.Add(new Human { weight = average_weight, generation_stage = gstage, aim_stage = astage, in_elevator = false, reached_stage = false, generation_time = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13), reserve_stage = 0 }); ;
            }
        }
    }
}
