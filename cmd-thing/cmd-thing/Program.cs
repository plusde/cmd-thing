﻿using cmd_thing.Logic;
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
            // I'm lazy  // AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA MACROS NOT LIKE THISSS BAD
            //Action<String> Console.Write = Console.Write;
            //Action<String> Console.Write = Console.WriteLine;


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
            i.DrawField()/*)*/; // don't output anymore, just create the field [tbh dont wanna know why you're doing this cursed commenting but aight]

            // read new inputs (skip we have a menu now)
            input1 = $"{ConsoleWidth / 2}";
            input2 = $"{ConsoleHeight / 2}";
            i.DrawField(input1, input2); // put char in created field

            var aziBabo = true;

            LoadMenu(i, aziBabo, ref drawingHealth, ref drawingArmor);

            // no goto :madcat:   
        }

        static void StartGame(InputHandler i, bool aziBabo, ref bool drawingHealth, ref bool drawingArmor) {
            while (!i.Run()) {
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
                            if (drawingHealth && c == '*') {
                                if (armHealthCounter <= i.CharHealth()) {
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
                            }
                            else
                                Console.Write(c);
                        }
                    } else {
                        int armHealthCounter = 0;
                        foreach (char c in i.DrawField()) {
                            if (drawingHealth && c == '*') {
                                if (armHealthCounter <= i.CharHealth()) {
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
                            } else
                                Console.Write(c);
                        }
                    }
                }
            }
        }
        static void LoadMenu(InputHandler i, bool aziBabo, ref bool drawingHealth, ref bool drawingArmor) {
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
                    StartGame(i, aziBabo, ref drawingHealth, ref drawingArmor);
            }
            return;
        }
    }
}

