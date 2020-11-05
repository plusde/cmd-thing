using cmd_thing.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmd_thing.Logic.Extentions {
    static class ItemInteractions {
        static public Dictionary<Property, int> ReturnStatistics(this Item i) {
            Dictionary<Property, int> output = new Dictionary<Property, int>();
            switch (i) {
                case Item.Sword:
                    output.Add(Property.WepRolls, 1);
                    output.Add(Property.WepDamage, 15);
                    output.Add(Property.WepDurability, 45);
                    output.Add(Property.WepStrengthReq, 5);
                    break;
                case Item.Armor:
                    output.Add(Property.ArmDamageRed, 10);
                    output.Add(Property.ArmBlockPerc, 20);
                    output.Add(Property.ArmDisplay, 2);
                    break;
                case Item.HealthPotion:
                    output.Add(Property.PotBonus, 20);
                    output.Add(Property.PotEffect, 0);
                    break;
            }
            return output;
        }
    }
}
