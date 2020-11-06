using cmd_thing.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmd_thing.Logic.Extentions {
    public static class EnemyInteraction {
        static public Dictionary<EnemyProperty, int> ReturnStatistics(this Enemy e) {
            Dictionary<EnemyProperty, int> output = new Dictionary<EnemyProperty, int>();
            switch (e) {
                case Enemy.Goblin:
                    output.Add(EnemyProperty.Damage, 3);
                    output.Add(EnemyProperty.DamageRolls, 2);
                    output.Add(EnemyProperty.BlockPerc, 13);
                    output.Add(EnemyProperty.DamageRed, 7);
                    output.Add(EnemyProperty.Health, 20);
                    break;
                case Enemy.Slime:
                    output.Add(EnemyProperty.Damage, 2);
                    output.Add(EnemyProperty.DamageRolls, 1);
                    output.Add(EnemyProperty.BlockPerc, 23);
                    output.Add(EnemyProperty.DamageRed, 5);
                    output.Add(EnemyProperty.Health, 15);
                    break;
            }
            return output;
        }
    }
}
