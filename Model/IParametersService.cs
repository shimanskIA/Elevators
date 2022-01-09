using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IParametersService
    {
        List<string> ImportParameters(string path);
        void ExportParameters(string path, string p1, string p2, string p3);
        void LoadParameters(string p1, string p2, string p3, bool rb1, bool rb2, bool rb3);
    }
}
