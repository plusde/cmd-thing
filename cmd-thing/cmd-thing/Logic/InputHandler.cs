using cmd_thing.Objects;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace cmd_thing.Logic {
    class InputHandler {
        readonly Game g;
        private bool recievedInput;
        private bool gameRunning;

        public bool RecievedInput {
            get { if (recievedInput) {
                    recievedInput = false;
                    return true;
                } else
                    return false;
            }
            set { recievedInput = value; }
        }
        public bool DisplayInventory { get; set; }

        // create game
        public InputHandler() {
            g = new Game();
            DisplayInventory = false;
        }

        /* actual input handling */

        // set field up
        public void SetFielDimensions(String s1, String s2) {
            int[] i = new int[2];
            if (int.TryParse(s1, out int i1))
                if (int.TryParse(s2, out int i2))
                    i = new int[] { i1, i2 };
            g.Field = new Field(i);
        }

        /* returning stuff because idk how to do it without using this class */

        // return the field
        public String DrawField() {
            if (gameRunning)
                return g.DrawChar();
            else {
                g.Field.Inside = String.Empty;
                return g.Field.Inside;
            }
        }
        // return field with character at fixed position, kinda useless.
        public String DrawField(String s1, String s2) {
            if (int.TryParse(s1, out int i1))
                if (int.TryParse(s2, out int i2))
                    g.Character/*.Coods */= new /*Utility.Coods*/Character(i1, i2); // character is never made so I need to make it now, but if I'd use this function every frame in the future it's better to not keep making new characters
                                                                                    // I'm using the other function now so no need to change this.
            return g.DrawChar();
        }
        // draw inventory
        public String DrawInventory() {
            g.Character.Inventory = String.Empty;
            return g.Character.Inventory;
        }
        // this should be the game
        public bool Run() {
            gameRunning = true;
            ConsoleKeyInfo ck;
            if (Console.KeyAvailable) {
                ck = Console.ReadKey(true);
                recievedInput = false;

                // exit the loop
                if(ck.Key == ConsoleKey.Escape)
                    return true;
                if (!DisplayInventory) {
                    // move
                    if (ck.Key == ConsoleKey.UpArrow || ck.Key == ConsoleKey.DownArrow || ck.Key == ConsoleKey.LeftArrow || ck.Key == ConsoleKey.RightArrow) {
                        g.MoveChar(ck.Key);
                        g.DrawChar();
                        recievedInput = true;
                    }
                    // interact
                    if (ck.Key == ConsoleKey.E) {
                        // break crate
                        g.Interaction();
                        g.DrawChar();
                        recievedInput = true;
                    }
                    // open inventory
                    if (ck.Key == ConsoleKey.I) {
                        DisplayInventory = true;
                        recievedInput = true;
                    }
                } else {
                    // close inventory
                    if (ck.Key == ConsoleKey.I) {
                        DisplayInventory = false;
                        recievedInput = true;
                    }
                }
            }
            return false;
        }
    }
}
