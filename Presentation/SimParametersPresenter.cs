using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Model;
using System.IO;

namespace Presentation
{
    public class SimParametersPresenter
    {
        private readonly IKernel _kernel;
        private readonly ISimulationParametersView _view;
        private readonly IParametersService _service;

        public SimParametersPresenter(IKernel kernel, ISimulationParametersView view, IParametersService service)
        {
            _kernel = kernel;

            _view = view;
            _view.ImportParameters += ImportParameters;
            _view.ExportParameters += ExportParameters;
            _view.LoadParameters += LoadParameters;
            _view.ManageHeightFieldActivity += ManageHeightFieldActivity;
            _view.ManageElNumberFieldActivity += ManageElNumberFieldActivity;
            _view.ManageElCapacityFieldActivity += ManageElCapacityFieldActivity;
            _service = service;
        }

        private void ImportParameters(string path)
        {
            List<string> fields = new List<string>();
            fields = _service.ImportParameters(path);
            _view.FillTheFields(fields[0], fields[1], fields[2]);
        }

        private void ExportParameters(string path, string p1, string p2, string p3)
        {
            _service.ExportParameters(path, p1, p2, p3);
        }

        private void LoadParameters(string p1, string p2, string p3, bool rb1, bool rb2, bool rb3)
        {
            _service.LoadParameters(p1, p2, p3, rb1, rb2, rb3);
            _view.Close();
            _kernel.Get<SimulationPresenter>().Run();
        }

        private void ManageHeightFieldActivity()
        {
            _view.HeightField_ActivityManager();
        }

        private void ManageElNumberFieldActivity()
        {
            _view.ElNumberField_ActivityManager();
        }

        private void ManageElCapacityFieldActivity()
        {
            _view.ElCapacityField_ActivityManager();
        }

        public void Run()
        {
            _view.Show();
            _view.FieldsNButtonsActivityController1();
        }
    }
}
