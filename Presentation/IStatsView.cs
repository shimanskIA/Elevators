using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public interface IStatsView : IView
    {
        void FillTheElevatorsGrid(int id, int transported_people, int rides, int empty_rides);
        void FillTheInfosGrid(int rides, int avg_waiting_time, int max_waiting_time, int total_waiting_time, int fa_amount, int fa_sum_length);
    }
}
