using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    class Room
    {
        public string RoomNum;
        public string Desc;
        public Room North, South, East, West; //Exits
        public Enemy RoomEnemy;
        public Item RoomItem;
        public Weapon RoomWeapon;
        public Puzzle RoomPuzzle;
        public Key RoomKey;
        public Room(string n, string d, string[] ex, Enemy en, Weapon w, Item i, Puzzle p, Key k)
        {
            RoomNum = n;
            Desc = d;
            RoomEnemy = en;
            RoomItem = i;
            RoomPuzzle = p;
            RoomWeapon = w;
            RoomKey = k;
        }
        public Room()
        {
            RoomNum = "r0";
            Desc = "";
            RoomEnemy = null;
            RoomItem = null;
            RoomPuzzle = null;
            North = null;
            South = null;
            East = null;
            West = null;
        }
    }
}
