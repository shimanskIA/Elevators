using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Service
{
    public interface IDeleteRuleService
    {
        List<string> GetRuleNames();
        void DeleteRule(string rule_name);
    }
}
