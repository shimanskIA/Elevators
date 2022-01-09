using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public interface ISimulationParametersView : IView
    {
        event Action<string, string, string, string> ExportParameters;
        event Action<string> ImportParameters;
        event Action<string, string, string, bool, bool, bool> LoadParameters;
        event Action ManageHeightFieldActivity;
        event Action ManageElNumberFieldActivity;
        event Action ManageElCapacityFieldActivity;

        void FillTheFields(string p1, string p2, string p3);

        void FieldsNButtonsActivityController1();
        void HeightField_ActivityManager();
        void ElNumberField_ActivityManager();
        void ElCapacityField_ActivityManager();
        //void ShowError(string message);
    }
}
