using cmd_thing.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmd_thing.Objects {
    class Character {
        public Coods Coods { get; set; }
        public Dictionary<Item, int> Inventory { get; set; }

        public Character(int x, int y) {
            Coods = new Coods(x, y);
            Inventory = new Dictionary<Item, int>();
        }

        public void PickUp(Item i) {
            if (Inventory.ContainsKey(i))
                Inventory[i]++;
            else
                Inventory.Add(i, 1);
        }
    }
}
