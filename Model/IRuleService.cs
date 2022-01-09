using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Service
{
    public interface IRuleService
    {
        void AddFixedGenRule(string time, string amount, string gstage, string astage, string interval, string weight, string name);
        void AddRandomGenRule(string time, string amount, string gstage, string astage, string weight, string name);
        void ExportLeftRule(string path, string time, string amount, string gstage, string astage, string weight, string rule_name);
        void ExportRightRule(string path, string time, string amount, string gstage, string astage, string interval, string weight, string rule_name);
        List<string> ImportRightRule(string path);
        List<string> ImportLeftRule(string path);
    }
}
