using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class MenuRepo
    {
        protected readonly List<Menu> _menuDirectory = new List<Menu>();

        public bool AddItemToMenu(Menu newMenuItem)
        {
            int startCount = _menuDirectory.Count;
            _menuDirectory.Add(newMenuItem);
            bool added = (_menuDirectory.Count > startCount) ? true : false;
            return added;
        }

        public List<Menu> GetMenu()
        {
            return _menuDirectory;
        }

        public bool DeleteMenuItem(Menu existingMenuItem)
        {
            bool delete = _menuDirectory.Remove(existingMenuItem);
            return delete;
        }
    }
}
