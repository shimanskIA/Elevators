using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IRepository<T> 
    {
        int Add(T obj);
        void Update(T obj);
        void Update(int element, T obj);
        void Remove(int id);
        void Save();
        T Find(int id);
        IEnumerable<T> GetAll();
    }
}
