using cmd_thing.Logic.Extentions;
using cmd_thing.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmd_thing.Objects {
    class Character {
        public Coods Coods { get; set; }
        private String inventoryString;
        private int uniqueItemCount;
        private readonly Dictionary<Item, int> inventory;

        // statistics

        public int MaxHealth { get; set; }
        public int Health { 
            get { return health; }
            set {
                health += value;
                if (health > MaxHealth)
                    health = MaxHealth;
            }
        }
        private int health;
        public int Armor { get; set; }

        public int UniqueItemCount {
            get { return uniqueItemCount; }
            set { uniqueItemCount = inventory.Count; }
        }

        // display of stats

        public String CharacterStats {
            get {
                String output = String.Empty;

                output += " Health: ";
                for (int i = 0; i < MaxHealth; i++)
                    output += "* ";
                output += "\t Armor: ";
                for (int i = 0; i < Armor; i++)
                    output += "* ";

                return output += "\n";
            }
        }
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
            MaxHealth = 20;
            Health = 20;
        }

        // item actions
        public void PickUp(Item i) {
            if (inventory.ContainsKey(i))
                inventory[i]++;
            else
                inventory.Add(i, 1);
        }
        public void Drop(Item i) {
            inventory[i]--;
            if (inventory[i] == 0)
                inventory.Remove(i);
        }
        public void Use(Item i) {
            switch (i) {
                case Item.Armor:
                    Armor = i.ReturnStatistics()[Property.ArmDisplay];
                    inventory[i]--;
                    break;
                case Item.HealthPotion:
                    switch (i.ReturnStatistics()[Property.PotEffect]) {
                        case 0:
                            Health += i.ReturnStatistics()[Property.PotBonus] / 5;
                            break;
                    }
                    inventory[i]--;
                    break;
            }
            if (inventory[i] == 0)
                inventory.Remove(i);
        }
    }
}
