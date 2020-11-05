using cmd_thing.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cmd_thing.Logic {
    class Game {
        public Field Field { get; set; }
        public Character Character { get; set; }

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
                    Character.Coods = new Character(Character.Coods.X, Character.Coods.Y - 1).Coods;
                    break;
                case ConsoleKey.DownArrow:
                    Character.Coods = new Character(Character.Coods.X, Character.Coods.Y + 1).Coods;
                    break;
                case ConsoleKey.LeftArrow:
                    Character.Coods = new Character(Character.Coods.X - 1, Character.Coods.Y).Coods;
                    break;
                case ConsoleKey.RightArrow:
                    Character.Coods = new Character(Character.Coods.X + 1, Character.Coods.Y).Coods;
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
                        case 'O':
                            Character.GiveRandomItem();
                            newField += '_';
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
