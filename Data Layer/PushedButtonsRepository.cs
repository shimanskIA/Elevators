using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataLayer
{
    public class PushedButtonsRepository : IRepository<bool>
    {
        private static List<bool> pushed_buttons = new List<bool> {
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false };
        public int Add(bool but1)
        {
            pushed_buttons.Add(but1);
            return 1;
        }

        public void Update(int index, bool pushed)
        {
            pushed_buttons[index] = pushed;
        }

        public void Update(bool index)
        {

        }

        public void Remove(int id)
        {
            //people_list.RemoveAll(c => c.Id == id);
        }

        public void Save()
        {
        }

        public bool Find(int id)
        {
            return pushed_buttons[id];
        }

        public IEnumerable<bool> GetAll()
        {
            return pushed_buttons;
        }
    }
}
