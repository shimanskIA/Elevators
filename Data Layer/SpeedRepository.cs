using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Entities;

namespace DataLayer
{
    public class SpeedRepository : IRepository<SpeedTiming>
    {
        private static List<SpeedTiming> speed_timings = new List<SpeedTiming> {
            new SpeedTiming { speed = 1, activated = true, activated_time = 0, activation_time = 0, Id = 0},
            new SpeedTiming { speed = 0.1, activated = false, activated_time = 0, activation_time = 0, Id = 1},
            new SpeedTiming { speed = 0.25, activated = false, activated_time = 0, activation_time = 0, Id = 2},
            new SpeedTiming { speed = 0.5, activated = false, activated_time = 0, activation_time = 0, Id = 3},
            new SpeedTiming { speed = 0.75, activated = false, activated_time = 0, activation_time = 0, Id = 4},
            new SpeedTiming { speed = 2, activated = false, activated_time = 0, activation_time = 0, Id = 5},
            new SpeedTiming { speed = 4, activated = false, activated_time = 0, activation_time = 0, Id = 6},
            new SpeedTiming { speed = 8, activated = false, activated_time = 0, activation_time = 0, Id = 7},
            new SpeedTiming { speed = 16, activated = false, activated_time = 0, activation_time = 0, Id = 8}
        };
        private static int end_index = 0;
        public int Add(SpeedTiming s1)
        {
            s1.Id = end_index;
            end_index += 1;
            speed_timings.Add(s1);
            return s1.Id;
        }

        public void Update(SpeedTiming s1)
        {
            var timing = speed_timings.Find(c => c.Id == s1.Id);
            if (timing != null)
            {
                timing.speed = s1.speed;
                timing.activated_time = s1.activated_time;
                timing.activation_time = s1.activation_time;
                timing.activated = s1.activated;
            }
        }

        public void Update(int index, SpeedTiming parameter)
        {

        }

        public void Remove(int id)
        {

        }

        public void Save()
        {
        }

        public SpeedTiming Find(int id)
        {
            return null;
        }

        public IEnumerable<SpeedTiming> GetAll()
        {
            return speed_timings;
        }
    }
}
