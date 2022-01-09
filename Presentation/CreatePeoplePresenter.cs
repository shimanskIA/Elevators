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
    public class CreatePeoplePresenter
    {
        private readonly IKernel _kernel;
        private readonly ICreatePeopleView _view;
        private readonly IPeopleService _service;

        public CreatePeoplePresenter(IKernel kernel, ICreatePeopleView view, IPeopleService service)
        {
            _kernel = kernel;

            _view = view;
            _view.GeneratePeople += GeneratePeople;
            _service = service;
        }

        private void GeneratePeople(string p1, string p2, string p3, string p4)
        {
            _service.GeneratePeople(p1, p2, p3, p4);
            _view.Close();
        }
        
        public void Run()
        {
            _view.Show();
        }
        
    }
}
