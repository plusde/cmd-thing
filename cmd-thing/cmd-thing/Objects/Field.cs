using System;
using System.Collections.Generic;
using System.Text;

namespace cmd_thing.Objects {
    class Field {
        public int Width { get; }
        public int Height { get; }
        public Field(int width, int height) {
            Width = width;
            Height = height;
        }
    }
}
