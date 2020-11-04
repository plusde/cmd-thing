using System;
using System.Collections.Generic;
using System.Text;

namespace cmd_thing.Objects {
    class Field {
        private String inside;
        private String rinside;
        public int Height { get; }
        public int Width { get; }
        public String Inside { 
            get { return inside; }
            set {
                if (value != String.Empty)
                    inside =  value;
                else {
                    if (rinside == String.Empty) {
                        for (int i = 0; i < Height; i++) {
                            for (int j = 0; j < Width; j++) {
                                switch (new Random().Next(15)) {
                                    case 13:
                                        rinside += ",";
                                        break;
                                    case 14:
                                        rinside += ".";
                                        break;
                                    default:
                                        rinside += " ";
                                        break;

                                }
                            }
                            if (i != Height - 1)
                                rinside += "\n";
                        }
                    } else
                        inside = rinside;
                }
            }
        }
        public Field (int[] i) {
            Height = i[0];
            Width = i[1];
            inside = String.Empty;
            rinside = String.Empty;
        }
    }
}
