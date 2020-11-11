using cmd_thing.Objects;
using cmd_thing.Utility;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace cmd_thing.Logic {
    class InputHandler {
        readonly Game g;
        private UI inventory;
        private UI menu;
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
        public bool StartGame { get; set; }

        // create game
        public InputHandler() {
            g = new Game();
            menu = new UI(1,3);
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
        // draw menu
        public String DrawMenu() {
            return g.DrawMenu();
        }

        /* stuff that belongs here even less */

        // output which menu button is selected
        public int SelectedMenuButton() {
            return menu.SelectedButton;
        }
        // output which inventory button is selected
        public int SelectedInvButton() {
            return inventory.SelectedButton;
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
            return g.Character.ArmorDisplay;
        }
        // the main menu
        public bool Menu() {
            ConsoleKeyInfo ck;
            if (Console.KeyAvailable) {
                ck = Console.ReadKey(true);
                recievedInput = false;
                StartGame = false;

                // go back to the game
                if (ck.Key == ConsoleKey.Escape) {
                    StartGame = true;
                    g.DrawChar();
                }
                // select ass
                if (ck.Key == ConsoleKey.UpArrow || ck.Key == ConsoleKey.DownArrow) {
                    switch (ck.Key) {
                        case ConsoleKey.UpArrow:
                            menu.SelectedButton--;
                            break;
                        case ConsoleKey.DownArrow:
                            menu.SelectedButton++;
                            break;
                    }
                    recievedInput = true;
                }
                // do selected ass
                if (ck.Key == ConsoleKey.Enter) {
                    if (menu.SelectedButton == 1) {
                        // start game
                        StartGame = true;
                        g.DrawChar();
                    } else if (menu.SelectedButton == 2) 
                        // settings or smth
                        return false;
                    else 
                        // exit button
                        return true;
                    recievedInput = true;
                    menu = new UI(1, 3);
                }

            }
            return false;
        }

        // map & inventory screen
        public bool Map() {
            gameRunning = true;
            ConsoleKeyInfo ck;
            if (Console.KeyAvailable) {
                ck = Console.ReadKey(true);
                recievedInput = false;

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
                        g.Character.UniqueItemCount = 0;
                        inventory = new UI(2, g.Character.UniqueItemCount);
                    }
                    // exit the loop
                    if (ck.Key == ConsoleKey.Escape) {
                        recievedInput = true;
                        return true;
                    }
                } else {
                    // select ass
                    if (ck.Key == ConsoleKey.UpArrow || ck.Key == ConsoleKey.DownArrow || ck.Key == ConsoleKey.LeftArrow || ck.Key == ConsoleKey.RightArrow) {
                        switch (ck.Key) {
                            case ConsoleKey.UpArrow:
                                inventory.SelectedButton-=2;
                                break;
                            case ConsoleKey.DownArrow:
                                inventory.SelectedButton+=2;
                                break;
                            case ConsoleKey.LeftArrow:
                                inventory.SelectedButton--;
                                break;
                            case ConsoleKey.RightArrow:
                                inventory.SelectedButton++;
                                break;
                        }
                        recievedInput = true;
                    }
                    // do action on selected ass
                    if (ck.Key == ConsoleKey.Enter) {
                        // get selected item as an item
                        int i = 0;
                        int j = 0;
                        bool skip = true;
                        bool read = false;
                        String item = String.Empty;
                        g.Character.UniqueItemCount = 0;
                        Item[] arr = new Item[g.Character.UniqueItemCount];
                        foreach (char c in DrawInventory()) {
                            if (c == '\n')
                                i++;
                            if (i == 3 && skip)
                                // first 3 lines don't matter
                                skip = false;
                            if (c == 'x' && !read) {
                                // enums get put after the x
                                read = true;
                                item = String.Empty;
                            }
                            if (c == '\t' && read) {
                                read = false;
                                // remove the chars that aren't the enum and parse it to the enums
                                arr[j++] = (Item) Enum.Parse(typeof(Item), item.Trim(new char[] { ' ', 'x', ':' }));
                            }
                            if (read)
                                item += c;
                        }
                        // do ass with it
                        if (inventory.SelectedButton % 2 == 1)
                            g.Character.Drop(arr[(int) Math.Floor((double) inventory.SelectedButton / 2)]);
                        else
                            g.Character.Use(arr[(int) Math.Floor((double) inventory.SelectedButton / 2) - 1]);

                        // update inventory
                        int sel = inventory.SelectedButton;
                        g.Character.UniqueItemCount = 0;
                        inventory = new UI(2, g.Character.UniqueItemCount) {
                            SelectedButton = sel
                        };
                        recievedInput = true;
                    }
                    // close inventory
                    if (ck.Key == ConsoleKey.I || ck.Key == ConsoleKey.Escape) {
                        DisplayInventory = false;
                        recievedInput = true;
                    }
                }
            }
            return false;
        }
    }
}
