using System;
using System.Collections.Generic;
using System.Text;

namespace cmd_thing.Utility {
    public enum Item {
        Sword,
        HealthPotion,
        Armor
    }
    public enum Property {
        // weapon properties
        WepStrengthReq,
        WepDurability,
        WepDamage,
        WepRolls,

        // potion properties
        PotBonus,
        PotEffect,
        /*
         * The other values have to be an int so I should probably write what int means what effect somewhere
         * So I'm gonna start it here:
         *
         * 0 : Health
         */

        // armor properties
        ArmBlockPerc,
        ArmDamageRed,
        ArmDisplay
    }
}
