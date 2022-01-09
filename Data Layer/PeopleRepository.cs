using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Entities;

namespace DataLayer
{
    public class PeopleRepository : IRepository<Human>
    {
        private static List<Human> people_list = new List<Human>();
        private static int end_index = 0;
        public int Add(Human obj)
        {
            obj.Id = end_index;
            end_index += 1;
            people_list.Add(obj);
            return obj.Id;
        }

        public void Update(Human h1)
        {
            var human = people_list.Find(c => c.Id == h1.Id);
            if (human != null)
            {
                human.name = h1.name;
                human.weight = h1.weight;
                human.generation_stage = h1.generation_stage;
                human.aim_stage = h1.aim_stage;
                human.waiting_time = h1.waiting_time;
                human.in_elevator = h1.in_elevator;
                human.delivery_time = h1.delivery_time;
                human.reached_stage = h1.reached_stage;
            }
        }

        public void Update(int index, Human h1)
        {
            
        }

        public void Remove(int id)
        {
            people_list.RemoveAll(c => c.Id == id);
        }

        public void Save()
        {
        }

        public Human Find(int id)
        {
            return people_list.Find(c => c.Id == id);
        }

        public IEnumerable<Human> GetAll()
        {
            return people_list;
        }
    }
}
