using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    class Item
    {
        public string Name;
        public int HealStr;
        public Item(string n, int s)
        {
            Name = n;
            HealStr = s;
        }
        public Item()
        {
            Name = "";
            HealStr = 0;
        }
    }
}
