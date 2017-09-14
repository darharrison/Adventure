using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Adventure
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Room> AllRooms = new List<Room>();
            string[] tokens;
            string detailLine;
            try
            {
                //StreamReader takes in the file of rooms.
                using (StreamReader sr = new StreamReader("rooms.txt"))
                //This whole thing just initializes the rooms into the program
                {
                    while (sr.Peek() >= 0)
                    {
                        detailLine = sr.ReadLine();
                        tokens = detailLine.Split(',');
                        Room tmpRoom = new Room();
                        tmpRoom.RoomNum = tokens[0];
                        tmpRoom.Desc = tokens[1].Trim();
                        AllRooms.Add(tmpRoom);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error in File: rooms.txt.");
                Environment.Exit(0);
            }
            List<Item> AllItems = new List<Item>();
            try
            {
                //StreamReader takes in the file of items.
                using (StreamReader sr = new StreamReader("items.txt"))
                //This whole thing just initializes the items into the program
                {
                    while (sr.Peek() >= 0)
                    {
                        detailLine = sr.ReadLine();
                        tokens = detailLine.Split(',');
                        Item tmpItem = new Item();
                        tmpItem.Name = tokens[0];
                        tmpItem.HealStr = Convert.ToInt32(tokens[1].Trim());
                        AllItems.Add(tmpItem);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error in File: items.txt.");
                Environment.Exit(0);
            }
            List<Weapon> AllWeapons = new List<Weapon>();
            try
            {
                //StreamReader takes in the file of items.
                using (StreamReader sr = new StreamReader("weapons.txt"))
                //This whole thing just initializes the items into the program
                {
                    while (sr.Peek() >= 0)
                    {
                        detailLine = sr.ReadLine();
                        tokens = detailLine.Split(',');
                        Weapon tmpWep = new Weapon();
                        tmpWep.Name = tokens[0];
                        tmpWep.Pwr = Convert.ToInt32(tokens[1].Trim());
                        AllWeapons.Add(tmpWep);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error in File: weapons.txt.");
                Environment.Exit(0);
            }
            List<Key> AllKeys = new List<Key>();
            try
            {
                //StreamReader takes in the file of items.
                using (StreamReader sr = new StreamReader("keys.txt"))
                //This whole thing just initializes the items into the program
                {
                    while (sr.Peek() >= 0)
                    {
                        detailLine = sr.ReadLine();
                        Key tmpKey = new Key();
                        tmpKey.Name = detailLine;
                        AllKeys.Add(tmpKey);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error in File: weapons.txt.");
                Environment.Exit(0);
            }
            //Room exits, could probably be done easier
            //I normally don't add extra spaces, but this is painful to do without them
            AllRooms[0].South = AllRooms[3];
            AllRooms[0].East = AllRooms[1];
            AllRooms[0].West = AllRooms[2];

            AllRooms[1].West = AllRooms[0];

            AllRooms[2].East = AllRooms[0];

            AllRooms[3].North = AllRooms[0];
            AllRooms[3].South = AllRooms[6];
            AllRooms[3].East = AllRooms[4];
            AllRooms[3].West = AllRooms[5];

            AllRooms[4].West = AllRooms[3];

            AllRooms[5].East = AllRooms[3];

            AllRooms[6].North = AllRooms[3];
            AllRooms[6].South = AllRooms[9];
            AllRooms[6].East = AllRooms[7];
            AllRooms[6].West = AllRooms[8];

            AllRooms[7].East = AllRooms[11];
            AllRooms[7].West = AllRooms[6];

            AllRooms[8].East = AllRooms[6];

            AllRooms[9].North = AllRooms[6];
            AllRooms[9].South = AllRooms[13];
            AllRooms[9].East = AllRooms[10];
            AllRooms[9].West = AllRooms[12];

            AllRooms[10].South = AllRooms[14];
            AllRooms[10].East = AllRooms[11];
            AllRooms[10].West = AllRooms[9];
            
            AllRooms[11].South = AllRooms[12];
            AllRooms[11].West = AllRooms[9];

            AllRooms[12].South = AllRooms[15];
            AllRooms[12].East = AllRooms[9];

            AllRooms[13].North = AllRooms[9];

            AllRooms[14].North = AllRooms[10];

            AllRooms[15].North = AllRooms[12];
            AllRooms[15].South = AllRooms[16];

            AllRooms[16].North = AllRooms[15];
            AllRooms[16].South = AllRooms[17];
            AllRooms[16].East = AllRooms[18];
            AllRooms[16].West = AllRooms[19];

            AllRooms[17].North = AllRooms[16];
            AllRooms[17].South = AllRooms[21];

            AllRooms[18].East = AllRooms[16];

            AllRooms[19].North = AllRooms[20];
            AllRooms[19].East = AllRooms[16];

            AllRooms[20].South = AllRooms[19];

            AllRooms[21].North = AllRooms[17];
            AllRooms[21].East = AllRooms[23];
            AllRooms[21].West = AllRooms[22];

            AllRooms[22].South = AllRooms[24];
            AllRooms[22].West = AllRooms[21];

            AllRooms[23].East = AllRooms[21];

            AllRooms[24].North = AllRooms[22];

            //Items
            AllRooms[2].RoomItem = AllItems[3];
            AllRooms[8].RoomItem = AllItems[2];
            AllRooms[9].RoomItem = AllItems[4];
            AllRooms[18].RoomItem = AllItems[0];
            AllRooms[21].RoomItem = AllItems[1];

            //Weapons
            AllRooms[3].RoomWeapon = AllWeapons[0];
            AllRooms[16].RoomWeapon = AllWeapons[1];
            AllRooms[23].RoomWeapon = AllWeapons[2];

            //Keys
            AllRooms[14].RoomKey = AllKeys[0];
            AllRooms[20].RoomKey = AllKeys[1];

            //Puzzles
            AllRooms[15].RoomPuzzle = new Puzzle(AllKeys[0].Name);
            AllRooms[22].RoomPuzzle = new Puzzle(AllKeys[1].Name);

            string[] validInp={ "N", "NORTH",  "S", "SOUTH", "E", "EAST", "W", "WEST", "PICKUP", "PICK UP", "QUIT", "DROP", "ATTACK"};  //All the valid commands
            Player player = new Player(100, new List<Item>(), new List<Key>(), new List<Weapon>());
            Console.WriteLine("Welcome to the adventure game!!");
            if (GetYesNo("Do you wish to play? <Y or N>:"))
            {
                Room currentRoom = AllRooms[0];
                string Ans = "";
                while (Ans != "QUIT")
                {
                    DescribeRoom(currentRoom);
                    Ans = Console.ReadLine().ToUpper();
                    switch (Ans)
                    {
                            //These cases can be condensed but I already did it and it works
                        case "N":
                            {
                                currentRoom = GoTo(currentRoom.North, currentRoom, player.Keys, new List<Room>(AllRooms));
                                break;
                            }
                        case "NORTH":
                            {
                                currentRoom = GoTo(currentRoom.North, currentRoom, player.Keys, new List<Room>(AllRooms));
                                break;
                            }
                        case "S":
                            {
                                currentRoom = GoTo(currentRoom.South, currentRoom, player.Keys, new List<Room>(AllRooms));
                                break;
                            }
                        case "SOUTH":
                            {
                                currentRoom = GoTo(currentRoom.South, currentRoom, player.Keys, new List<Room>(AllRooms));
                                break;
                            }
                        case "E":
                            {
                                currentRoom = GoTo(currentRoom.East, currentRoom, player.Keys, new List<Room>(AllRooms));
                                break;
                            }
                        case "EAST":
                            {
                                currentRoom = GoTo(currentRoom.East, currentRoom, player.Keys, new List<Room>(AllRooms));
                                break;
                            }
                        case "W":
                            {
                                currentRoom = GoTo(currentRoom.West, currentRoom, player.Keys, new List<Room>(AllRooms));
                                break;
                            }
                        case "WEST":
                            {
                                currentRoom = GoTo(currentRoom.West, currentRoom, player.Keys, new List<Room>(AllRooms));
                                break;
                            }
                        case "PICKUP":
                            {
                                if (currentRoom.RoomItem != null) //Check item
                                {
                                    Console.WriteLine("You picked up the {0}, ({1})\n", currentRoom.RoomItem.Name, currentRoom.RoomItem.HealStr);
                                    player.Items.Add(currentRoom.RoomItem);
                                    currentRoom.RoomItem = null;
                                }
                                else if (currentRoom.RoomWeapon != null) //Check weapon
                                {
                                    Console.WriteLine("You picked up the {0}, ({1})\n", currentRoom.RoomWeapon.Name, currentRoom.RoomWeapon.Pwr);
                                    player.Weapons.Add(currentRoom.RoomWeapon);
                                    currentRoom.RoomWeapon = null;
                                }
                                else if (currentRoom.RoomKey != null) //Check key
                                {
                                    Console.WriteLine("You picked up the {0}\n", currentRoom.RoomKey.Name);
                                    player.Keys.Add(currentRoom.RoomKey);
                                    currentRoom.RoomKey = null;
                                }
                                else //Nothing to pick up
                                {
                                    Console.WriteLine("There is nothing in this room to pick up.");
                                    break;
                                }
                                break;
                            }
                        case "INVENTORY":
                            {
                                DisplayItems(player.Items, player.Weapons, player.Keys);
                                break;
                            }
                            
                        case "DROP ITEM":
                            {
                                if (player.Items.Count() != 0)
                                {
                                    DisplayItems(player.Items, player.Weapons, player.Keys);
                                    Console.WriteLine("Which item would you like to drop?");
                                    string input = Console.ReadLine();
                                    foreach (Item i in player.Items)
                                    {
                                         if(input.ToUpper() == i.Name.ToUpper())
                                         {
                                             Console.WriteLine("You dropped {0}.", i.Name);
                                             currentRoom.RoomItem = i;
                                             player.Items.Remove(i);
                                             break;
                                         }
                                    else
                                    {
                                        Console.WriteLine("You don't have an item by that name.");
                                        break;
                                    }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You have no items.");
                                }
                                break;
                            }
                        case "DROP WEAPON":
                            {
                                if (player.Weapons.Count() != 0)
                                {
                                    DisplayItems(player.Items, player.Weapons, player.Keys);
                                    Console.WriteLine("Which weapon would you like to drop?");
                                    string input = Console.ReadLine();
                                    foreach (Weapon w in player.Weapons)
                                    {
                                        if (input.ToUpper() == w.Name.ToUpper())
                                        {
                                            Console.WriteLine("You dropped {0}.", w.Name);
                                            currentRoom.RoomWeapon = w;
                                            player.Weapons.Remove(w);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("You don't have a weapon by that name.");
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You have no weapons.");
                                }
                                break;
                            }
                        case "DROP KEY":
                            {
                                if (player.Keys.Count() != 0)
                                {
                                    DisplayItems(player.Items, player.Weapons, player.Keys);
                                    Console.WriteLine("Which key would you like to drop?");
                                    string input = Console.ReadLine();
                                    foreach (Key k in player.Keys)
                                    {
                                        if (input.ToUpper() == k.Name.ToUpper())
                                        {
                                            Console.WriteLine("You dropped {0}.", k.Name);
                                            currentRoom.RoomKey = k;
                                            player.Keys.Remove(k);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("You don't have a key by that name.");
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You have no keys.");
                                }
                                break;
                            }
                        case "HELP":
                            {
                                Console.WriteLine("These are all the commands for the game:\nNORTH/ N, SOUTH/ S, EAST/ E, WEST/ W, PICKUP, DROP ITEM, DROP WEAPON, DROP KEY, INVENTORY, ATTACK");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Please enter a valid command: ");
                                break;
                            }
                    }
                }    
             }
            else
            {
              Console.WriteLine("Exiting Game...");
              Environment.Exit(0);
            }
                
        }
        static bool GetYesNo(string prompt)
        {
            string[] valid = { "YES", "Y", "NO", "N" };
            string ans;
            ans = GetString(prompt, valid, "?Invalid response, please reenter");
            return (ans == "YES" || ans == "Y");
        }

        static string GetString(string prompt, string[] valid, string error)
        {
            string response;
            bool OK = false;
            do
            {
                Console.Write(prompt);
                response = Console.ReadLine().ToUpper();
                foreach (string s in valid) if (response == s.ToUpper()) OK = true;
                if (!OK) Console.WriteLine(error);
            } while (!OK);
            return response;
        }
         static void DescribeRoom(Room room)
         {
            Console.WriteLine(room.Desc);

            // If there is an item/ weapon/ key, say so
            if (room.RoomItem != null)
            {
                Console.WriteLine("There is {0} here.", room.RoomItem.Name);
            }
            if (room.RoomWeapon != null)
            {
                Console.WriteLine("There is a {0} here.", room.RoomWeapon.Name);
            }
            if (room.RoomKey != null)
            {
                Console.WriteLine("There is a {0} here.", room.RoomKey.Name);
            }

            // Show possible exits
            Console.WriteLine("Paths: {0}{2}{1}{3}\n",
            room.North == null ? "" : "North ",
            room.East == null ? "" : "East ",
            room.South == null ? "" : "South ",
            room.West == null ? "" : "West");
         }
        static void DisplayItems(List<Item> playerItems, List<Weapon> playerWeapons, List<Key> playerKeys)
        {
            if((playerItems.Count>0) || (playerWeapons.Count > 0) || (playerKeys.Count > 0)) //Get the number of items in player's inventory
            {
                Console.WriteLine("****Inventory****");
                Console.WriteLine("Items\n");
                foreach (Item item in playerItems)
                {
                    Console.WriteLine("{0}; {1} healing power.\n", item.Name, item.HealStr); //Display Items
                }
                Console.WriteLine("Weapons\n");
                foreach (Weapon weapon in playerWeapons)
                {
                    Console.WriteLine("{0}; {1} power.\n", weapon.Name, weapon.Pwr); //Display Items
                }
                Console.WriteLine("Keys\n");
                foreach (Key key in playerKeys)
                {
                    Console.WriteLine("{0}\n", key.Name); //Display Items
                }
            }
            else
            {
                Console.WriteLine("You are not carrying any items.");           
            }
            Console.WriteLine();
        }
        static Room GoTo(Room nextRoom, Room currentRoom, List<Key> keys, List<Room> rooms)
        {
            if (nextRoom != null) //Check if the direction player choses exists
            {
                if (currentRoom.RoomPuzzle != null && keys.Count == 0) //Check if current room has puzzle (No keys)
                {
                    Console.WriteLine("This door is locked, and you have no keys.\n"); //Display challenge text
                    if (currentRoom.RoomPuzzle.Name == "Brass Key") //First puzzle
                        currentRoom = rooms[13]; //Go back
                    else if (currentRoom.RoomPuzzle.Name == "Gold Key") //Second puzzle
                        currentRoom = rooms[21]; //Go back
                }
                else if (currentRoom.RoomPuzzle != null && keys.Count != 0) //Check if current room has puzzle
                {
                    bool match = false;
                    foreach(Key k in keys)
                    {
                        if(k.Name.ToUpper() == currentRoom.RoomPuzzle.Name.ToUpper())
                        {
                            Console.WriteLine("You used the {0} to open the door.", k.Name);
                            currentRoom = nextRoom;
                            match = true;
                        }
                    }
                    if(match == false)
                        Console.WriteLine("This door is locked. You need another key.\n"); //Display challenge text
                }
                else //No challenge, so move to the new room
                    currentRoom = nextRoom;
            }
            else
            {
                Console.WriteLine("There is no exit in that direction.");
            }
            return currentRoom;
        }
    }
}