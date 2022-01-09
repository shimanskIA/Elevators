using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataLayer
{
    public class SimParametersRepository : IRepository<int>
    {
        private static List<int> sim_parameters = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

        public int Add(int p1)
        {
            sim_parameters.Add(p1);
            return p1;
        }

        public void Update(int index)
        {

        }

        public void Update(int parameter, int index)
        {
            sim_parameters[index] = parameter;
        }

        public void Remove(int id)
        {

        }

        public void Save()
        {
        }

        public int Find(int id)
        {
            return id;
        }

        public IEnumerable<int> GetAll()
        { 
            return sim_parameters;
        }
    }
}
