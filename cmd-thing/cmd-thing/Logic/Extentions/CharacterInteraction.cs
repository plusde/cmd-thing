using cmd_thing.Objects;
using cmd_thing.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmd_thing.Logic {
    static class CharacterInteraction {
        static public void GiveRandomItem(this Character c) {
            switch (new Random().Next(4)) {
                case 0:
                    c.PickUp(Item.Sword);
                    break;
                case 1:
                    c.PickUp(Item.HealthPotion);
                    break;
                case 2:
                    c.PickUp(Item.LeatherArmor);
                    break;
                case 3:
                    c.PickUp(Item.FullPlate);
                    break;
            }
        }

        static public void EncounterEnemy0(this Character c) {
            switch (new Random().Next(2)) {
                case 0:
                    c.Encounter(Enemy.Goblin);
                    break;
                case 1:
                    c.Encounter(Enemy.Slime);
                    break;
            }
        }
    }
}
