using cmd_thing.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmd_thing.Objects {
    class Character {
        private Coods coods;

        public Character(int x, int y) {
            coods = new Coods(x, y);
        }
    }
}
