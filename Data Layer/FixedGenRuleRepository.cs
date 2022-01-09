using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Entities;

namespace DataLayer
{
    public class FixedGenRuleRepository : IRepository<FixedGenRule>
    {
        private static List<FixedGenRule> fixed_gen_rule_list = new List<FixedGenRule>();
        private static int end_index = 0;
        public int Add(FixedGenRule rule1)
        {
            rule1.Id = end_index;
            end_index += 1;
            fixed_gen_rule_list.Add(rule1);
            return rule1.Id;
        }

        public void Update(FixedGenRule rule1)
        {
            var rule = fixed_gen_rule_list.Find(c => c.Id == rule1.Id);
            if (rule != null)
            {
                rule.time_distance = rule1.time_distance;
                rule.passed = rule1.passed;
                rule.multiplicated = rule1.multiplicated;
                rule.gen_while_paused = rule1.gen_while_paused;
            }
        }

        public void Update(int index, FixedGenRule rule1)
        {

        }

        public void Remove(int id)
        {
            fixed_gen_rule_list.RemoveAll(c => c.Id == id);
        }

        public void Save()
        {

        }

        public FixedGenRule Find(int id)
        {
            return fixed_gen_rule_list.Find(c => c.Id == id);
        }

        public IEnumerable<FixedGenRule> GetAll()
        {
            return fixed_gen_rule_list;
        }
    }
}
