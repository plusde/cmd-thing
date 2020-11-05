using cmd_thing.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmd_thing.Objects {
    class UI {
        private int maxY;           // I want to get this stuff to work but fsr it doesn't. 
        private int maxX;           // for inventory it just performs the action on the latest selected item.
        private int selectedButton; // for the main screen it'll do the same ig.
        public int SelectedButton { get; set; }
        public UI(int maxX, int maxY) {
            this.maxX = maxX;
            this.maxY = maxY;
            SelectedButton = 1;
        }
    }
}
