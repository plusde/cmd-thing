﻿using cmd_thing.Objects;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace cmd_thing.Logic {
    class InputHandler {
        readonly Game g;
        private UI ui;
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
                return g.Character.CharacterStats + g.DrawChar();
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
            return g.Character.CharacterStats + g.DrawChar();
        }
        // draw inventory
        public String DrawInventory() {
            g.Character.Inventory = String.Empty;
            return g.Character.CharacterStats + g.Character.Inventory;
        }

        /* stuff that belongs here even less */

        // output which inventory button is selected
        public int SelectedInvButton() {
            return ui.selectedButton;
        }
        // output the character's max health
        public int CharMaxHealth() {
            return g.Character.MaxHealth;
        }
        // output the character's health
        public int CharHealth() {
            return g.Character.Health;
        }
        // output the character's armor
        public int CharArmor() {
            return g.Character.Armor;
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
                        ui = new UI(2, g.Character.UniqueItemCount);
                    }
                } else {
                    // select ass
                    if (ck.Key == ConsoleKey.UpArrow || ck.Key == ConsoleKey.DownArrow || ck.Key == ConsoleKey.LeftArrow || ck.Key == ConsoleKey.RightArrow) {
                        switch (ck.Key) {
                            case ConsoleKey.UpArrow:
                                ui.selectedButton-=2;
                                break;
                            case ConsoleKey.DownArrow:
                                ui.selectedButton+=2;
                                break;
                            case ConsoleKey.LeftArrow:
                                ui.selectedButton--;
                                break;
                            case ConsoleKey.RightArrow:
                                ui.selectedButton++;
                                break;
                        }
                        recievedInput = true;
                    }
                    // do action on selected ass
                    if (ck.Key == ConsoleKey.Enter) {
                        if(ui.selectedButton % 2 == 1) {
                            g.Character.Drop(ui.selectedButton % 2 - 1);
                        } else {
                            g.Character.Use(ui.selectedButton % 2);
                        }
                        recievedInput = true;
                    }
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
