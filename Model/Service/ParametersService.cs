using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace Model.Service
{
    public class ParametersService : IParametersService
    {
        private readonly IRepository<int> _prepository;
        private readonly IRepository<Elevator> _elrepository;
        private readonly IRepository<SpeedTiming> _srepository;
        public ParametersService(IRepository<int> prepository, IRepository<Elevator> elrepository, IRepository<SpeedTiming> srepository)
        {
            _prepository = prepository;
            _elrepository = elrepository;
            _srepository = srepository;
        }
        public List<string> ImportParameters(string path)
        {
            List<string> fields = new List<string>();
            StreamReader rdr = new StreamReader(path);
            string p1 = rdr.ReadLine();
            string p2 = rdr.ReadLine();
            string p3 = rdr.ReadLine();
            rdr.Close();
            fields.Add(p1);
            fields.Add(p2);
            fields.Add(p3);
            return fields;
        }

        public void ExportParameters(string path, string p1, string p2, string p3)
        {
            StreamWriter wrt = new StreamWriter(path);
            wrt.WriteLine(p1);
            wrt.WriteLine(p2);
            wrt.WriteLine(p3);
            wrt.Close();
        }

        public void LoadParameters(string p1, string p2, string p3, bool rb1, bool rb2, bool rb3)
        {
            int type = 0;
            if (rb1 == true)
            {
                type = 0;
            }
            if (rb2 == true)
            {
                type = 1;
            }
            if (rb3 == true)
            {
                type = 2;
            }
            int height = int.Parse(p1);
            int amount = int.Parse(p2);
            int cap = int.Parse(p3);
            _prepository.Update(height, 0);
            _prepository.Update(amount, 1);
            _prepository.Update(cap, 2);
            _prepository.Update(type, 3);
            for (int i = 0; i < amount; i++)
            {
                _elrepository.Add(new Elevator { capacity = cap, Id = i, actual_stage = 1, mode = type, speed = 5, mission_stage = 0, actual_weight = 0, inner_orders = new List<int>(), people_inside = new List<int>(), reserve_stage = 0, transported_people = 0, rides = 0, empty_rides = 0, up = true, was_empty = true }) ;
            }
        }
    }
}
