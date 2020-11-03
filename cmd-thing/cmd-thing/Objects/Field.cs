using System;
using System.Collections.Generic;
using System.Text;

namespace cmd_thing.Objects {
    class Field {
        private String inside;
        public int Height { get; }
        public int Width { get; }
        public String Inside { 
            get { return inside; }
            set {
                inside = String.Empty;
                for (int i = 0; i < Height; i++) {
                    for (int j = 0; j < Width; j++) {
                        Random r = new Random();
                        switch (r.Next(15)) {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                                inside += " ";
                                break;
                            case 13:
                                inside += ",";
                                break;
                            case 14:
                                inside += ".";
                                break;
                        }
                    }
                    if(i!=Height-1)
                        inside += "\n";
                }
            }
        }
        public Field (int[] i) {
            Height = i[0];
            Width = i[1];
        }
    }
}
