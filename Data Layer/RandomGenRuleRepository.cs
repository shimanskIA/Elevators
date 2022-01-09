using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Entities;

namespace DataLayer
{
    public class RandomGenRuleRepository : IRepository<RandomGenRule>
    {
        private static List<RandomGenRule> random_gen_rule_list = new List<RandomGenRule>();
        private static int end_index = 0;
        public int Add(RandomGenRule rule1)
        {
            rule1.Id = end_index;
            end_index += 1;
            random_gen_rule_list.Add(rule1);
            return rule1.Id;
        }

        public void Update(RandomGenRule rule1)
        {
            
        }

        public void Update(int index, RandomGenRule rule1)
        {

        }

        public void Remove(int id)
        {
            random_gen_rule_list.RemoveAll(c => c.Id == id);
        }

        public void Save()
        {

        }

        public RandomGenRule Find(int id)
        {
            return random_gen_rule_list.Find(c => c.Id == id);
        }

        public IEnumerable<RandomGenRule> GetAll()
        {
            return random_gen_rule_list;
        }
    }
}
