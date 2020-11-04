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
                                switch (new Random().Next(100)) {
                                    case 87:
                                        rinside += "O";
                                        break;
                                    case 88:
                                    case 89:
                                    case 90:
                                    case 91:
                                    case 92:
                                    case 93:
                                        rinside += ",";
                                        break;
                                    case 94:
                                    case 95:
                                    case 96:
                                    case 97:
                                    case 98:
                                    case 99:
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
                    }
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
