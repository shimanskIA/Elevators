using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public interface IDeleteRuleView : IView
    {
        event Action<string> DeleteRule;
        void FillTheBox(List<string> rule_names);
        void ClearTheRow();
    }
}
