using cmd_thing.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmd_thing.Objects {
    class UI {
        private readonly int maxY;          // I want to get this stuff to work but fsr it doesn't. 
        private readonly int maxX;          // for inventory it just performs the action on the latest selected item.
        private int selectedButton;         // for the main screen it'll do the same ig.
        public int SelectedButton { 
            get { return selectedButton; }
            set {
                int v = value;
                int m = maxX * maxY;
                if (v > m)
                    selectedButton = m;
                else if (v < 1)
                    selectedButton = 1;
                else
                    selectedButton = v;

            }
        }
        public UI(int maxX, int maxY) {
            this.maxX = maxX;
            this.maxY = maxY;
            selectedButton = 1;
        }
    }
}
