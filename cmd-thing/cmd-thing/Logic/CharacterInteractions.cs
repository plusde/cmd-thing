using cmd_thing.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmd_thing.Logic {
    static class CharacterInteractions {
        static public void GiveRandomItem(this Character c) {
            switch (new Random().Next(3)) {
                case 0:
                    c.PickUp(Utility.Item.Sword);
                    break;
                case 1:
                    c.PickUp(Utility.Item.HealthPotion);
                    break;
                case 2:
                    c.PickUp(Utility.Item.Armor);
                    break;
            }
        }
    }
}
