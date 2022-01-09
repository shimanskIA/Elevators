using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class FixedGenRule : EntityBase
    {
        public int time { get; set; }
        public int amount_of_people { get; set; }
        public int generation_stage { get; set; }
        public int aim_stage { get; set; }
        public int interval { get; set; }
        public int average_weight { get; set; }
        public int time_distance { get; set; }
        public bool multiplicated { get; set; }
        public int time_changed { get; set; }
        public int gen_while_paused { get; set; }
        public int add_count { get; set; }
        public double mult_old { get; set; }
        public bool passed { get; set; }
        public int load_time { get; set; }
        public string rule_name { get; set; }
    }
}
