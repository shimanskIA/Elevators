using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public interface ISetRuleView : IView
    {
        event Action<string, string, string, string, string, string, string> AddFixedGenRule;
        event Action<string, string, string, string, string, string> AddRandomGenRule;
        event Action<string, string, string, string, string, string, string> ExportLeftRule;
        event Action<string, string, string, string, string, string, string, string> ExportRightRule;
        event Action<string> ImportLeftRule;
        event Action<string> ImportRightRule;
        event Action ManageFixedGenRBActivity;
        event Action ManageRandomGenRBActivity;
        event Action ManageRightFieldActivity;
        event Action ManageLeftFieldActivity;
        event Action ManageFieldsNButtonsActivity;

        void FixedGen_RB_ActivityManager();
        void RandomGen_RB_ActivityManager();
        void LeftField_ActivityManager();
        void RightField_ActivityManager();
        void FieldsNButtonsActivityManager1();
        void FillTheFields(List<string> parameters);
    }
}
