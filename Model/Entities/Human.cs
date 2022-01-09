using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Human : EntityBase
    {
        public string name { get; set; }
        public int weight { get; set; }
        public int generation_stage { get; set; }
        public int aim_stage { get; set; }
        public int reserve_stage { get; set; }
        public int generation_time { get; set; }
        public int time_before_change { get; set; }
        public double waiting_time { get; set; }
        public int delivery_time { get; set; }
        public bool in_elevator { get; set; }
        public bool reached_stage { get; set; }
    }
}
