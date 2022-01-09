using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace Model.Service
{
    public class DeleteRuleService : IDeleteRuleService
    {
        private readonly IRepository<FixedGenRule> _fg_repository;
        private readonly IRepository<RandomGenRule> _rg_repository;
        public DeleteRuleService(IRepository<FixedGenRule> fg_repository, IRepository<RandomGenRule> rg_repository)
        {
            _fg_repository = fg_repository;
            _rg_repository = rg_repository;
        }

        public List<string> GetRuleNames()
        {
            List<string> rule_names = new List<string>();
            IEnumerable<FixedGenRule> fg_list = _fg_repository.GetAll();
            IEnumerable<RandomGenRule> rg_list = _rg_repository.GetAll();
            for (int i = 0; i < fg_list.Count(); i++)
            {
                rule_names.Add(fg_list.ElementAt(i).rule_name);
            }
            for (int i = 0; i < rg_list.Count(); i++)
            {
                rule_names.Add(rg_list.ElementAt(i).rule_name);
            }
            return rule_names;
        }

        public void DeleteRule(string rule_name)
        {
            IEnumerable<FixedGenRule> fg_list = _fg_repository.GetAll();
            IEnumerable<RandomGenRule> rg_list = _rg_repository.GetAll();
            for (int i = 0; i < fg_list.Count(); i++)
            {
                if (rule_name.Equals(fg_list.ElementAt(i).rule_name))
                {
                    _fg_repository.Remove(fg_list.ElementAt(i).Id);
                    break;
                }
            }
            for (int i = 0; i < rg_list.Count(); i++)
            {
                if (rule_name.Equals(rg_list.ElementAt(i).rule_name))
                {
                    _rg_repository.Remove(rg_list.ElementAt(i).Id);
                    break;
                }
            }
        }
    }
}
