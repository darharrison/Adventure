using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    class Enemy
    {
        public string Name;
        public int Health;
        public int Atk;

        public Enemy(string n, int h, int a)
        {
            Health = h;
            Name = n;
            Atk = a;
        }
        public Enemy()
        {
            Health = 0;
            Name = "";
            Atk = 0;
        }
    }
}
