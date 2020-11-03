using System;
using System.Collections.Generic;
using System.Text;

namespace cmd_thing.Objects {
    class Field {
        private String inside;
        public int Width { get; }
        public int Height { get; }
        public String Inside { 
            get { return inside; }
            set {
                inside = String.Empty;
                for (int i = 0; i < Width; i++) {
                    for (int j = 0; j < Height; j++) {
                        Random r = new Random();
                        switch (r.Next(10)) {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 7:
                                inside += " ";
                                break;
                            case 8:
                                inside += ",";
                                break;
                            case 9:
                                inside += ".";
                                break;
                            case 10:
                                inside += ":";
                                break;
                        }
                    }
                    inside += "\n";
                }
            }
        }
        public Field (int[] i) {
            Width = i[0];
            Height = i[1];
        }
    }
}
