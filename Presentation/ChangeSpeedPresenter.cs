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
    public class ChangeSpeedPresenter
    {
        private readonly IKernel _kernel;
        private readonly IChangeSpeedView _view;
        private readonly IChangeSpeedService _service;

        public ChangeSpeedPresenter(IKernel kernel, IChangeSpeedView view, IChangeSpeedService service)
        {
            _kernel = kernel;

            _view = view;
            _view.ChangeSpeed += ChangeSpeed;
            _service = service;
        }

        private void ChangeSpeed(double speed)
        {
            _service.ChangeSpeed(speed);
            _view.Close();
        }
        public void Run()
        {
            _view.Show();
        }
    }
}