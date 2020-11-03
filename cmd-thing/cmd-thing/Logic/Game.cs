using cmd_thing.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmd_thing.Logic {
    class Game {
        public Field Field { get; set; }
        public Character Character { get; set; }

        public String drawChar() {
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
    }
}
