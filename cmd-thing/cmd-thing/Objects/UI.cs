using cmd_thing.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmd_thing.Objects {
    class UI {
        private int maxY;
        private int maxX;
        public int selectedButton { get; set; }
        public UI(int maxX, int maxY) {
            this.maxX = maxX;
            this.maxY = maxY;
            selectedButton = 1;
        }
    }
}
