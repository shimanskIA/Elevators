using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Model;
using Model.Entities;

namespace DataLayer
{
    public class PoolOfThreads : IRepository<Thread>
    {
        private static List<Thread> thread_pool = new List<Thread>();
        public int Add(Thread t1)
        {
            thread_pool.Add(t1);
            return 1;
        }

        public void Update(Thread t1)
        {
           
        }

        public void Update(int index, Thread t1)
        {

        }

        public void Remove(int id)
        {

        }

        public void Save()
        {
        }

        public Thread Find(int id)
        {
            return thread_pool[0];
        }

        public IEnumerable<Thread> GetAll()
        {
            return thread_pool;
        }
    }
}
