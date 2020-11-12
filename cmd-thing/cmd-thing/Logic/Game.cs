using cmd_thing.Logic.Extentions;
using cmd_thing.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cmd_thing.Logic {
    class Game {
        public Field Field { get; set; }
        public Character Character { get; set; }
        public bool EnemyEncountered { get; set; }
        private bool alreadyAttacked;

        // put char in field
        public String DrawChar() {
            String output = String.Empty;
            int ctry = 0;
            int ctrx = 0;

            foreach (char c in Field.Inside) {
                if (c == '\n') { // newline = lower y level
                    ++ctry;
                    ctrx = 0;    // newline = new x
                }
                if (ctry == Character.Coods.Y && ctrx++ == Character.Coods.X) // place # if x & y match
                    output += "#";
                else
                    output += c;
            }
            return output;
        }
        // this does what it says
        public void MoveChar(ConsoleKey ck) {
            switch (ck) {
                case ConsoleKey.UpArrow:
                    Character.Coods = new Utility.Coods(Character.Coods.X, Character.Coods.Y - 1);
                    break;
                case ConsoleKey.DownArrow:
                    Character.Coods = new Utility.Coods(Character.Coods.X, Character.Coods.Y + 1);
                    break;
                case ConsoleKey.LeftArrow:
                    Character.Coods = new Utility.Coods(Character.Coods.X - 1, Character.Coods.Y);
                    break;
                case ConsoleKey.RightArrow:
                    Character.Coods = new Utility.Coods(Character.Coods.X + 1, Character.Coods.Y);
                    break;
            }
        }

        // check if smth is nearby & interact with it
        public void Interaction() {
            String newField = String.Empty;
            // counter for the x and y, same as DrawChar function
            int ctry = 0;
            int ctrx = 0;
            // create arrays with possible x and y values
            int[] arry = { Character.Coods.Y - 1, Character.Coods.Y, Character.Coods.Y + 1};
            int[] arrx = { Character.Coods.X - 1, Character.Coods.X, Character.Coods.X + 1};
            foreach (char c in Field.Inside) {
                if (c == '\n') {
                    ++ctry;
                    ctrx = 0;
                }
                // only check for the x and y of stuff char can interact with
                if (arry.Contains(ctry) && arrx.Contains(ctrx++)) {
                    switch (c) {
                        // found crate
                        case 'O':
                            Character.GiveRandomItem();
                            newField += '_';
                            break;
                        // found enemy
                        case 'X':
                            Character.EncounterEnemy0();
                            alreadyAttacked = false;
                            EnemyEncountered = true;
                            break;
                        // nothing nearby to interact with
                        default:
                            newField += c;
                            break;
                    }
                } else
                    newField += c;
            }
            Field.Inside = newField;
        }

        // fighting screen
        public String DrawEnemyEncounter() {
            String hws = String.Empty;
            String inb = String.Empty;
            String stats = String.Empty;
            String report = String.Empty;
            String options = String.Empty;
            String header = String.Empty;
            String footer = String.Empty;

            // header of encounter screen
            header += $"\n Combat site: {Character.Enemy} ";
            int olength = header.Length;
            for (int i = 0; i < 100 - olength; i++)
                header += "-";
            header += " \n";
            header += "|";
            for (int i = 0; i < 98; i++)
                header += " ";
            header += "|\n";

            // inb
            inb += "|";
            for (int i = 0; i < 98; i++)
                inb += " ";
            inb += "|\n";

            // footer
            footer += "|";
            for (int i = 0; i < 98; i++)
                footer += " ";
            footer += "|\n ";
            for (int i = 0; i < 98; i++)
                footer += "-";

            // combat stats
            stats += $"| {Character.EnemyOutput}";
            for (int i = 0; i < (Field.Width - (stats.Length + 2)); i++)
                hws += " ";
            stats += hws + " |\n" + inb;

            // combat report
            if (Character.CombatReport != String.Empty)
                alreadyAttacked = true;
            else
                alreadyAttacked = false;
            if (Character.Enemy.ReturnStatistics()[Utility.EnemyProperty.Health] < 0)
                EnemyEncountered = false;

            if (alreadyAttacked) {
                hws = String.Empty;
                Character.CombatReport = String.Empty;
                for (int i = 0; i < (Field.Width - (Character.CombatReport.Length + 4)); i++)
                    hws += " ";
                report += "| " + Character.CombatReport + hws + " |\n" + inb;
            }

            // combat options
            options += $"[Use {Character.LeftHand}]   [Run]   [Use {Character.RightHand}]";
            hws = String.Empty;
            for (int i = 0; i < Math.Floor((double) (Field.Width - (options.Length + 4)) / 2); i++)
                hws += " ";
            if (options.Length % 2 == 1)
                options += " ";
            options = "| " + hws + options + hws + " |\n";

            return header + stats + report + options + footer;
        }

        // menu screen
        public String DrawMenu() {
            String ws = String.Empty;
            String content = String.Empty;

            for (int i = 0; i < (Field.Height - 3) / 2; i++)
                ws += "\n";

            String[] options = { "[Play]", "[Settings]", "[Quit]"};

            foreach(String s in options) {
                for(int i = 0; i < (Field.Width - s.Length) / 2; i++)
                    content += " ";
                content += $"{s}\n";
            }

            return ws + content + ws;
        }
    }
}
