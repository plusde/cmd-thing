using cmd_thing.Logic;
using System;

namespace cmd_thing {
    class Program {
        static void Main(string[] args) {
            // I'm lazy
            Action<String> cw = Console.Write;
            Action<String> cwl = Console.WriteLine;

            // read inputs
            Console.ForegroundColor = ConsoleColor.Gray;
            cw("Height: ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            String input1 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            cw("Width: ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            String input2 = Console.ReadLine();

            // send to inputhandler

            // stop
            Console.ReadKey();
        }
    }
}
