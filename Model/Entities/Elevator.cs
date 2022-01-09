using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Elevator : EntityBase
    {
        public int capacity { get; set; }
        public int actual_weight { get; set; }
        public int speed { get; set; }
        public int actual_stage { get; set; }
        public int mode { get; set; }
        public int rides { get; set; }
        public int empty_rides { get; set; }
        public int transported_people { get; set; }
        public bool up { get; set; }
        public bool was_empty { get; set; }
        public int mission_stage { get; set; }
        public int reserve_stage { get; set; }
        public bool on_mission { get; set; }
        public List<int> inner_orders { get; set; }
        public List<int> people_inside { get; set; }
    }
}
