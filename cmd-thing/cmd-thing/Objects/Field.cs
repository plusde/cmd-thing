﻿using System;
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
                                int r = new Random().Next(200);

                                if (r > 190 && r < 199)
                                    rinside += ".";
                                else if (r > 182 && r < 191)
                                    rinside += ",";
                                else if (r == 182)
                                    rinside += "O";
                                else if (r == 181)
                                    rinside += "X";
                                else
                                    rinside += " ";
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
