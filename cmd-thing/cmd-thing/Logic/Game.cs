using cmd_thing.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmd_thing.Logic {
    class Game {
        public Field Field { get; set; }
        public Character Character { get; set; }

        public String DrawChar() {
            String output = String.Empty;
            int ctrh = 0;
            int ctrw = 0;

            foreach (char c in Field.Inside) {
                if (c == '\n') {
                    ++ctrh;
                    ctrw = 0;
                }
                if (ctrh == Character.Coods.Y && ctrw++ == Character.Coods.X)
                    output += "#";
                else
                    output += c;
            }
            return output;
        }

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
    }
}
