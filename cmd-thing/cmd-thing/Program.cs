using cmd_thing.Logic;
using System;
using System.Timers;

namespace cmd_thing {
    class Program {
        static void Main(string[] args) {
            InputHandler i = new InputHandler();
            const int ConsoleHeight = 29;
            const int ConsoleWidth = 100;

            bool drawingHealth = true;
            bool drawingArmor = false;

            // I'm lazy
            Action<String> cw = Console.Write;
            Action<String> cwl = Console.WriteLine;

            // say some ass
            cwl("Welcome to cmd-thing.\n");

            // read inputs (not anymore I locked them)
            Console.ForegroundColor = ConsoleColor.Gray;
            cw("Height: ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            cw(ConsoleHeight+"\n");
            String input1 = ConsoleHeight + "";
            Console.ForegroundColor = ConsoleColor.Gray;
            cw("Width: ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            cw(ConsoleWidth+"");
            String input2 = ConsoleWidth + "";
            Console.ReadKey();

            // send to inputhandler
            i.SetFielDimensions(input1, input2);

            // display ass
            Console.Clear();
            cw(i.DrawField());

            // read new inputs
            Console.ForegroundColor = ConsoleColor.Gray;
            cw("\nChar X: ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            input1 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            cw("Char Y: ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            input2 = Console.ReadLine();

            // display new ass
            Console.Clear();
            foreach (char c in i.DrawField(input1, input2)) {
                if (c == '#') {
                    Console.ForegroundColor = ConsoleColor.White;
                    cw(c + "");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                else
                    cw(c + "");
            }

        // input reading
        Game:
            if (!i.Run()) {
                // update the ass
                if (i.RecievedInput) {
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
        }
    }
}
