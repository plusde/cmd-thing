using cmd_thing.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmd_thing.Objects {
    class Character {
        public Coods Coods { get; set; }

        public Character(int x, int y) {
            Coods = new Coods(x, y);
        }
    }
}
