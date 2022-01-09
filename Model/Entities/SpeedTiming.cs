using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class SpeedTiming : EntityBase
    {
        public double speed { get; set; }
        public int activated_time { get; set; }
        public int activation_time { get; set; }
        public bool activated { get; set; }
    }
}
