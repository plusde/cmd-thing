using System;
using System.Collections.Generic;
using System.Text;

namespace cmd_thing.Utility {
    public enum Item {
        BareHands,
        BirthdaySuit,
        Sword,
        HealthPotion,
        LeatherArmor,
        FullPlate
    }
    public enum ItemProperty {
        // weapon properties
        WepStrengthReq,
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
    public enum Enemy {
        // Enemy0
        Goblin,
        Slime
    }
    public enum EnemyProperty {
        Health,
        Damage,
        DamageRolls,
        BlockPerc,
        DamageRed
    }
}
