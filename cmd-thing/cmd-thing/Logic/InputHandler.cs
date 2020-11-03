using cmd_thing.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmd_thing.Logic {
    class InputHandler {
        Game g;

        // create game
        public InputHandler() {
            g = new Game();
        }

        /* actual input handling */

        // set field up
        public void SetFielDimensions(String s1, String s2) {
            int[] i = new int[2];
            if (int.TryParse(s1, out int i1))
                if (int.TryParse(s2, out int i2))
                    i = new int[] { i1, i2 };
            g.Field = new Field(i);
        }

        /* returning stuff because idk how to do it without using this class */

        // return the field
        public String DrawField() {
            g.Field.Inside = String.Empty;
            return g.Field.Inside;
        }
    }
}
