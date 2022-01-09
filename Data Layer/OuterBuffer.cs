using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataLayer
{
    public class OuterBuffer : IRepository<byte>
    {
        private static List<byte> buffer = new List<byte>();
        //private static int end_index = 0;
        public int Add(byte order)
        {
            buffer.Add(order);
            /*obj.Id = _end_index;
            _end_index += 1;
            _data.Add(obj);
            return obj.Id;*/
            return order;
        }

        public void Update(byte index)
        {
            /*var character = _data.Find(c => c.Id == obj.Id);
            if (character != null)
                character.Name = obj.Name;*/
        }

        public void Update(int index, byte index2)
        {
            
        }

        public void Remove(int index)
        {
            buffer.Remove(buffer.ElementAt(index));
        }

        public void Save()
        {
        }

        public byte Find(int var)
        {
            byte flag;
            byte var1 = (byte)var;
            if (buffer.Contains(var1) == true)
            {
                flag = 1;
            }
            else
            {
                flag = 0;
            }
            return flag;
        }

        public IEnumerable<byte> GetAll()
        {
            return buffer;
        }
    }
}
