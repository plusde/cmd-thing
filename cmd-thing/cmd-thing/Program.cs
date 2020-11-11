using cmd_thing.Logic;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Timers;

namespace cmd_thing
{
    class Program
    {
        static void Main(string[] args)
        {
            InputHandler i = new InputHandler();
            const int ConsoleHeight = 29;
            const int ConsoleWidth = 100;
            bool drawingHealth = false;
            bool drawingArmor = false;
            bool healthArmorText = false;
            // I'm lazy  // AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA MACROS NOT LIKE THISSS BAD
            //Action<String> cw = Console.Write;
            //Action<String> cwl = Console.WriteLine;


            // say some ass
            Console.Write("Welcome to cmd-thing.");

            // read inputs (not anymore I locked them)
            String input1 = $"{ConsoleHeight}";
            String input2 = $"{ConsoleWidth}";

            // send to inputhandler
            i.SetFielDimensions(input1, input2);

            // display ass
            Console.Clear();
            /*Console.Write(*/
            i.DrawField()/*)*/; // don't output anymore, just create the field [tbh dont wanna know why you're doing this cursed commenting but aight] because it's funny :gladders:

            // read new inputs (skip we have a menu now)
            input1 = $"{ConsoleWidth / 2}";
            input2 = $"{ConsoleHeight / 2}";
            i.DrawField(input1, input2); // put char in created field

            var aziBabo = true;

            LoadMenu(i, aziBabo, ref drawingHealth, ref drawingArmor, ref healthArmorText);

            // no goto :madcat:   
        }

        static void StartGame(InputHandler i, ref bool drawingHealth, ref bool drawingArmor, ref bool healthArmorText) { // no azibabo :aziBabo:
            while (!i.Map()) {
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
                            if (drawingArmor || drawingHealth)
                                healthArmorText = true;
                            else
                                healthArmorText = false;
                            if (drawingHealth && c == '*') {
                                if (armHealthCounter < i.CharHealth()) {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write(c);
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                } else
                                    Console.Write(c);
                                if (++armHealthCounter == i.CharMaxHealth()) {
                                    drawingHealth = false;
                                    drawingArmor = true;
                                    armHealthCounter = 0;
                                }
                            } else if (drawingArmor && c == '*') {
                                if (++armHealthCounter == i.CharArmor())
                                    drawingArmor = false;
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write(c);
                                Console.ForegroundColor = ConsoleColor.Gray;
                            } else if (c == '\n') {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                drawingArmor = false;
                                Console.Write(c);
                            } else if (c == '|' || c == '-') {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write(c);
                                Console.ForegroundColor = ConsoleColor.Gray;
                            } else if (c == '[') {
                                if (++bracketCtr == i.SelectedInvButton()) {
                                    Console.BackgroundColor = ConsoleColor.Gray;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                }
                                Console.Write(c);
                            } else if (bracketCtr == i.SelectedInvButton() && c == ']') {
                                Console.BackgroundColor = ConsoleColor.Gray;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(c);
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Gray;
                            } else if (healthArmorText)
                                Console.Write(c);
                            else {
                                Console.Write(c);
                            }
                        }
                    } else {
                        int armHealthCounter = 0;
                        foreach (char c in i.DrawField()) {
                            if (drawingHealth && c == '*') {
                                if (armHealthCounter < i.CharHealth()) {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write(c);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                } else
                                    Console.Write(c);
                                if (++armHealthCounter == i.CharMaxHealth()) {
                                    drawingHealth = false;
                                    drawingArmor = true;
                                    armHealthCounter = 0;
                                }
                            } else if (drawingArmor && c == '*') {
                                if (++armHealthCounter == i.CharArmor())
                                    drawingArmor = false;
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write(c);
                                Console.ForegroundColor = ConsoleColor.Gray;
                            } else if (c == '#') {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(c);
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                            } else {
                                // idk what you changed but stuff became white :anger
                                // should always be gray now
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write(c);
                            }
                        }
                    }
                }
            }
        }
        static void LoadMenu(InputHandler i, bool aziBabo, ref bool drawingHealth, ref bool drawingArmor, ref bool healthArmorText) {
            // fuck you im using a while loop :dontcare:
            while (!i.Menu()) {
                // update this ass too
                if (i.RecievedInput || aziBabo) {
                    if (aziBabo == true)
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
                            Console.Write(c);
                        } else if (bracketCtr == i.SelectedMenuButton() && c == ']') {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(c);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Gray;
                        } else
                            Console.Write(c);
                    }
                }
                if (i.StartGame)
                    StartGame(i, ref drawingHealth, ref drawingArmor, ref healthArmorText); // azibabo wasn't needed here
            }
            return;
        }
    }
}

