using cmd_thing.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmd_thing.Logic.Extentions {
    static class ItemInteraction {
        static public Dictionary<ItemProperty, int> ReturnStatistics(this Item i) {
            Dictionary<ItemProperty, int> output = new Dictionary<ItemProperty, int>();
            switch (i) {
                case Item.BareHands:
                    output.Add(ItemProperty.WepRolls, 1);
                    output.Add(ItemProperty.WepDamage, 4);
                    output.Add(ItemProperty.WepStrengthReq, 0);
                    output.Add(ItemProperty.ArmDamageRed, 2);
                    output.Add(ItemProperty.ArmBlockPerc, 30);
                    break;
                case Item.Sword:
                    output.Add(ItemProperty.WepRolls, 1);
                    output.Add(ItemProperty.WepDamage, 15);
                    output.Add(ItemProperty.WepStrengthReq, 5);
                    break;
                case Item.BirthdaySuit:
                    output.Add(ItemProperty.ArmDamageRed, 0);
                    output.Add(ItemProperty.ArmBlockPerc, 50);
                    output.Add(ItemProperty.ArmDisplay, 0);
                    break;
                case Item.LeatherArmor:
                    output.Add(ItemProperty.ArmDamageRed, 10);
                    output.Add(ItemProperty.ArmBlockPerc, 20);
                    output.Add(ItemProperty.ArmDisplay, 2);
                    break;
                case Item.FullPlate:
                    output.Add(ItemProperty.ArmDamageRed, 20);
                    output.Add(ItemProperty.ArmBlockPerc, 40);
                    output.Add(ItemProperty.ArmDisplay, 4);
                    break;
                case Item.HealthPotion:
                    output.Add(ItemProperty.PotBonus, 20);
                    output.Add(ItemProperty.PotEffect, 0);
                    break;
            }
            return output;
        }
    }
}
