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
    public class DeleteRulePresenter
    {
        private readonly IKernel _kernel;
        private readonly IDeleteRuleView _view;
        private readonly IDeleteRuleService _service;

        public DeleteRulePresenter(IKernel kernel, IDeleteRuleView view, IDeleteRuleService service)
        {
            _kernel = kernel;

            _view = view;
            _view.DeleteRule += DeleteRule;
            _service = service;
        }

        private void DeleteRule(string rule_name)
        {
            _service.DeleteRule(rule_name);
            _view.ClearTheRow();
        }
        public void Run()
        {
            List<string> rule_names = _service.GetRuleNames();
            _view.FillTheBox(rule_names);
            _view.Show();
        }
    }
}
