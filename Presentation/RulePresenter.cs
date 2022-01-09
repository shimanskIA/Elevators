using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Model.Service;
using Model;


namespace Presentation
{
    public class RulePresenter
    {
        private readonly IKernel _kernel;
        private readonly ISetRuleView _view;
        private readonly IRuleService _service;

        public RulePresenter(IKernel kernel, ISetRuleView view, IRuleService service)
        {
            _kernel = kernel;

            _view = view;
            _view.AddFixedGenRule += AddFixedGenRule;
            _view.AddRandomGenRule += AddRandomGenRule;
            _view.ExportLeftRule += ExportLeftRule;
            _view.ExportRightRule += ExportRightRule;
            _view.ImportLeftRule += ImportLeftRule;
            _view.ImportRightRule += ImportRightRule;
            _view.ManageFieldsNButtonsActivity += ManageFieldsNButtonsActivity;
            _view.ManageFixedGenRBActivity += ManageFixedGenRBActivity;
            _view.ManageRandomGenRBActivity += ManageRandomGenRBActivity;
            _view.ManageRightFieldActivity += ManageRightFieldActivity;
            _view.ManageLeftFieldActivity += ManageLeftFieldActivity;
            _service = service;
        }

        private void AddFixedGenRule(string time, string amount, string gstage, string astage, string interval, string weight, string name)
        {
            _service.AddFixedGenRule(time, amount, gstage, astage, interval, weight, name);
            _view.Close();
        }

        private void AddRandomGenRule(string time, string amount, string gstage, string astage, string weight, string name)
        {
            _service.AddRandomGenRule(time, amount, gstage, astage, weight, name);
            _view.Close();
        }

        private void ExportLeftRule(string path, string time, string amount, string gstage, string astage, string weight, string rule_name)
        {
            _service.ExportLeftRule(path, time, amount, gstage, astage, weight, rule_name);
        }

        private void ExportRightRule(string path, string time, string amount, string gstage, string astage, string interval, string weight, string rule_name)
        {
            _service.ExportRightRule(path, time, amount, gstage, astage, interval, weight, rule_name);
        }

        private void ImportLeftRule(string path)
        {
            List<string> fields = new List<string>();
            fields = _service.ImportLeftRule(path);
            _view.FillTheFields(fields);
        }

        private void ImportRightRule(string path)
        {
            List<string> fields = new List<string>();
            fields = _service.ImportRightRule(path);
            _view.FillTheFields(fields);
        }

        private void ManageFieldsNButtonsActivity()
        {
            _view.FieldsNButtonsActivityManager1();
        }

        private void ManageFixedGenRBActivity()
        {
            _view.FixedGen_RB_ActivityManager();
        }

        private void ManageRandomGenRBActivity()
        {
            _view.RandomGen_RB_ActivityManager();
        }

        private void ManageRightFieldActivity()
        {
            _view.RightField_ActivityManager();
        }

        private void ManageLeftFieldActivity()
        {
            _view.LeftField_ActivityManager();
        }

        public void Run()
        {
            _view.Show();
        }

    }
}
