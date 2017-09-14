using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    class Player
    {
        public int Health;
        public List<Item> Items;
        public List<Weapon> Weapons;
        public List<Key> Keys;
        public Player(int h, List<Item> i, List<Key> k, List<Weapon> w)
        {
            Health = h;
            Items = i;
            Weapons = w;
            Keys = k;
        }
    }
}
