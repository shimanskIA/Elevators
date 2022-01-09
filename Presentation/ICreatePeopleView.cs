using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public interface ICreatePeopleView : IView
    {
        event Action<string, string, string, string> GeneratePeople;
    }
}
