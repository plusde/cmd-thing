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
        // return field with character
        public String DrawField(String s1, String s2) {
            int[] i = new int[2];
            if (int.TryParse(s1, out int i1))
                if (int.TryParse(s2, out int i2))
                    g.Character/*.Coods */= new /*Utility.Coods*/Character(i1, i2); // character is never made so I need to make it now, but if I'd use this function every frame in the future it's better to not keep making new characters
            return g.drawChar();
        }
        // this should be the game
        public void Run() {

        }
    }
}
