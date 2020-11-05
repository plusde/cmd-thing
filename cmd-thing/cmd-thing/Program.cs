using cmd_thing.Logic;
using System;
using System.Timers;

namespace cmd_thing {
    class Program {
        static void Main(string[] args) {
            InputHandler i = new InputHandler();
            const int ConsoleHeight = 29;
            const int ConsoleWidth = 100;

            bool drawingHealth;
            bool drawingArmor;

            // I'm lazy
            Action<String> cw = Console.Write;
            Action<String> cwl = Console.WriteLine;

            // say some ass
            cwl("Welcome to cmd-thing.");

            // read inputs (not anymore I locked them)
            String input1 = $"{ConsoleHeight}";
            String input2 = $"{ConsoleWidth}";

            // send to inputhandler
            i.SetFielDimensions(input1, input2);

            // display ass
            Console.Clear();
            /*cw(*/i.DrawField()/*)*/; // don't output anymore, just create the field

            // read new inputs (skip we have a menu now)
            input1 = $"{ConsoleWidth / 2}";
            input2 = $"{ConsoleHeight / 2}";
            i.DrawField(input1, input2); // put char in created field

            var aziBabo = true;

            goto Menu;

        // input reading
        Game:
            if (!i.Run()) {
                // update the ass
                if (i.RecievedInput || i.StartGame) {
                    i.StartGame = false;
                    Console.Clear();
                    drawingHealth = true;
                    drawingArmor = false;
                    if (i.DisplayInventory) {
                        int bracketCtr = 0;
                        int armHealthCounter = 0;
                        foreach (char c in i.DrawInventory()) {
                            if (drawingHealth && c=='*') {
                                if (armHealthCounter <= i.CharHealth()) {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    cw(c + "");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                } else
                                    cw(c + "");
                                if (++armHealthCounter == i.CharMaxHealth()) {
                                    drawingHealth = false;
                                    drawingArmor = true;
                                    armHealthCounter = 0;
                                }
                            } else if (drawingArmor && c=='*') {
                                if (++armHealthCounter == i.CharArmor())
                                    drawingArmor = false;
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                cw(c + "");
                                Console.ForegroundColor = ConsoleColor.Gray;
                            } else if (c == '|' || c == '-') {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                cw(c + "");
                                Console.ForegroundColor = ConsoleColor.Gray;
                            } else if (c == '[') {
                                if(++bracketCtr == i.SelectedInvButton()) {
                                    Console.BackgroundColor = ConsoleColor.Gray;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                }
                                cw(c + "");
                            } else if (bracketCtr == i.SelectedInvButton() && c == ']') {
                                Console.BackgroundColor = ConsoleColor.Gray;
                                Console.ForegroundColor = ConsoleColor.Black;
                                cw(c + "");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Gray;
                            } else
                                cw(c + "");
                        }
                    } else {
                        int armHealthCounter = 0;
                        foreach (char c in i.DrawField()) {
                            if (drawingHealth && c == '*') {
                                if (armHealthCounter <= i.CharHealth()) {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    cw(c + "");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                } else
                                    cw(c + "");
                                if (++armHealthCounter == i.CharMaxHealth()) {
                                    drawingHealth = false;
                                    drawingArmor = true;
                                    armHealthCounter = 0;
                                }
                            } else if (drawingArmor && c == '*') {
                                if (++armHealthCounter == i.CharArmor())
                                    drawingArmor = false;
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                cw(c + "");
                                Console.ForegroundColor = ConsoleColor.Gray;
                            } else if (c == '#') {
                                Console.ForegroundColor = ConsoleColor.White;
                                cw(c + "");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                            } else
                                cw(c + "");
                        }
                    }
                }
                goto Game;
            }
        // main menu, pressing esc will get you here
        Menu:
            if (!i.Menu()) {
                // update this ass too
                if (i.RecievedInput || aziBabo) {
                    if(aziBabo == true)
                        aziBabo = false;
                    else // fsr console still gets cleared.
                        Console.Clear();
                    int bracketCtr = 0;
                    foreach (char c in i.DrawMenu()) {
                        if (c == '[') {
                            if (++bracketCtr == i.SelectedMenuButton()) {
                                Console.BackgroundColor = ConsoleColor.Gray;
                                Console.ForegroundColor = ConsoleColor.Black;
                            }
                            cw(c + "");
                        } else if (bracketCtr == i.SelectedMenuButton() && c == ']') {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                            cw(c + "");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Gray;
                        } else
                            cw(c + "");
                    }
                }
                if (i.StartGame)
                    goto Game;
                goto Menu;
            }
        }
    }
}
