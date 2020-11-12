using cmd_thing.Logic.Extentions;
using cmd_thing.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmd_thing.Objects {
    class Character {
        public Coods Coods { get; set; }

        private int health;
        private int strength;
        private readonly Dictionary<Item, int> inventory;
        private String inventoryString;
        private int uniqueItemCount;

        // equips
        public Item LeftHand { get; set; }  // block, except for 2-handed items
        public Item RightHand { get; set; } // attack
        public Item Armor { get; set; }     // it's armor

        // enemies
        public Dictionary<EnemyProperty, int> EnemyStats { get; set; }
        public Enemy Enemy { get; set; }
        public String EnemyOutput {
            get {
                String output = String.Empty;

                output += "Health: ";
                for (int i = 0; i < Enemy.ReturnStatistics()[EnemyProperty.Health]; i++)
                    output += "* ";

                return output;
            }
        }

        // combat values

        private Item UsedItem;
        private int strengthDealt;
        private int damageDealt;
        public int DamageDealt { 
            get { return damageDealt; }
            set {
                strengthDealt = new Random().Next(strength);
                damageDealt = new Random().Next(UsedItem.ReturnStatistics()[ItemProperty.WepDamage] + 1) * UsedItem.ReturnStatistics()[ItemProperty.WepRolls] + strengthDealt; 
            }
        }
        private int damageRecieved;
        public int DamageRecieved {
            get { return damageRecieved; }
            set {
                if (Enemy.ReturnStatistics()[EnemyProperty.Health] > 0)
                    damageRecieved = new Random().Next(Enemy.ReturnStatistics()[EnemyProperty.Damage] + 1) * Enemy.ReturnStatistics()[EnemyProperty.DamageRolls];
                else
                    damageRecieved = 0;
            }
        }
        private int dealtBlocked;
        public int DealtBlocked {
            get { return dealtBlocked; }
            set {
                if (new Random().Next(100) > Enemy.ReturnStatistics()[EnemyProperty.BlockPerc])
                    dealtBlocked = new Random().Next(Enemy.ReturnStatistics()[EnemyProperty.DamageRed] + 1);
                if (damageDealt - dealtBlocked > 0)
                    dealtBlocked = damageDealt;
            }
        }
        private int recievedBlocked;
        public int RecievedBlocked {
            get { return recievedBlocked; }
            set {
                if (new Random().Next(100) > Armor.ReturnStatistics()[ItemProperty.ArmBlockPerc])
                    recievedBlocked = new Random().Next(Armor.ReturnStatistics()[ItemProperty.ArmDamageRed] + 1);
                // left hand blocks
                // this would make you better always use the left hand when attacking with dual weapons but oh well
                if(UsedItem == LeftHand)
                    if (new Random().Next(100) > UsedItem.ReturnStatistics()[ItemProperty.ArmBlockPerc])
                        recievedBlocked += new Random().Next(UsedItem.ReturnStatistics()[ItemProperty.ArmDamageRed] + 1);
                if (damageRecieved - recievedBlocked > 0)
                    recievedBlocked = damageRecieved;
            }
        }

        private String combatReport;
        public String CombatReport {
            get { return combatReport; }
            set {
                String output = String.Empty;
                if (damageDealt == dealtBlocked)
                    output += $"The {Enemy} dodged your attack, no damage was dealt";
                else
                    output += $"Your attack hit! You hit the {Enemy} for {damageDealt} ({strengthDealt} was from strength).";
                if (damageDealt > dealtBlocked && dealtBlocked != damageDealt)
                    output += $"\nHowever, the attack was partially blocked. {damageDealt - dealtBlocked} damage was dealt to the {Enemy}";
                if (Enemy.ReturnStatistics()[EnemyProperty.Health] == 0)
                    output += $"\nThe {Enemy} has died, you have won.";
                else {
                    output += $"\nThe {Enemy} counterattacks, ";
                    if (damageRecieved == recievedBlocked)
                        output += "however, you dodged the attack. 0 damage was dealt.";
                    else
                        output += $"The attack hit! You were hit for {damageRecieved} damage. Luckily, because of your {Armor}, only {damageRecieved - recievedBlocked} landed.";
                }
                combatReport = output;
            }
        }

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

        public double Strength {
            get { return (double) strength / 100; }
            set {
                if (new Random().Next(3) == 2)
                    strength++;
            }
        }

        public int ArmorDisplay { get; set; }
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
                for (int i = 0; i < ArmorDisplay; i++)
                    output += "* ";

                return output += "\n";
            }
        }
        public String Inventory {
            get { return inventoryString; }
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
                    if (s.Length > longest)
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
            LeftHand = Item.BareHands;
            RightHand = Item.BareHands;
            Armor = Item.BirthdaySuit;
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
                case Item.FullPlate:
                case Item.LeatherArmor:
                    ArmorDisplay = i.ReturnStatistics()[ItemProperty.ArmDisplay];
                    Armor = i;
                    inventory[i]--;
                    break;
                case Item.HealthPotion:
                    switch (i.ReturnStatistics()[ItemProperty.PotEffect]) {
                        case 0:
                            Health += i.ReturnStatistics()[ItemProperty.PotBonus] / 5;
                            break;
                    }
                    inventory[i]--;
                    break;
                case Item.Sword:
                    RightHand = i;
                    inventory[i]--;
                    break;
            }
            if (inventory[i] == 0)
                inventory.Remove(i);
        }

        // enemy actions
        public void Encounter(Enemy e) {
            Enemy = e;
            EnemyStats = new Dictionary<EnemyProperty, int>();
            foreach(KeyValuePair<EnemyProperty,int> ei in e.ReturnStatistics())
                EnemyStats.Add(ei.Key,ei.Value);
        }

        public void LeftAttack() {
            UsedItem = LeftHand;
            Attack();
        }
        public void RightAttack() {
            UsedItem = RightHand;
            Attack();
        }
        public void NoAttack() {
            DamageRecieved = 0;
            RecievedBlocked = 0;

            // text
            String output = String.Empty;
            output += $"\nThe {Enemy} attacks you while fleeing";
            if (damageRecieved == recievedBlocked)
                output += ", however, you dodged the attack. 0 damage was dealt.";
            else
                output += $". The attack hit!\nYou were hit for {damageRecieved} damage. Luckily, because of your {Armor}, only {damageRecieved - recievedBlocked} landed.";
            combatReport = output;
        }
        private void Attack() {
            DamageDealt = 0;
            DamageRecieved = 0;
            RecievedBlocked = 0;
            dealtBlocked = 0;
        }
        public bool Flee() {
            int chance = new Random().Next(50 + strength);
            if (chance > new Random().Next(100))
                return true;
            else
                return false;
        }
        public void ResetEncounter() {
            combatReport = String.Empty;
        }
    }
}
