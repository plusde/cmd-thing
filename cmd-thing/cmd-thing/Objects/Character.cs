using cmd_thing.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmd_thing.Objects {
    class Character {
        public Coods Coods { get; set; }
        private String inventoryString;
        private readonly Dictionary<Item, int> inventory;
        public String Inventory {
            get {
                return inventoryString;
            }
            set {
                String output = String.Empty;
                String[] entries = new string[inventory.Count];

                // header of inventory screen
                output += "\n Inventory ";
                int olength = output.Length;
                for (int i = 0; i < 100 - olength; i++)
                    output += "-";
                output += " \n";
                output += "|";
                for (int i = 0; i < 98; i++)
                    output += " ";
                output += "|\n";

                // body
                int ctr = 0;
                foreach (KeyValuePair<Item, int> i in inventory)
                    entries[ctr++] = $"| {i.Value} x {i.Key}:";      // first add everything
                int longest = 0;
                foreach (String s in entries)
                    if (s.Length >= longest)
                        longest = s.Length;                          // check what's longest
                for (int i = 0; i < entries.Length; i++) {
                    int entryLength = entries[i].Length;
                    for (int j = 0; j < longest - entryLength; j++)
                        entries[i] += " ";
                    entries[i] += "\t[DROP]  -  [USE]";
                    entryLength = entries[i].Length;
                    for (int j = 0; j < 95 - entryLength; j++)
                        entries[i] += " ";
                    output += entries[i] + "|\n";
                }

                // footer
                output += "|";
                for (int i = 0; i < 98; i++)
                    output += " ";
                output += "|\n ";
                for (int i = 0; i < 98; i++)
                    output += "-";

                inventoryString = output;
            }
        }

        public Character(int x, int y) {
            Coods = new Coods(x, y);
            inventory = new Dictionary<Item, int>();
        }

        public void PickUp(Item i) {
            if (inventory.ContainsKey(i))
                inventory[i]++;
            else
                inventory.Add(i, 1);
        }
    }
}
