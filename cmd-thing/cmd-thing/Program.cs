using cmd_thing.Logic;
using System;

namespace cmd_thing {
    class Program {
        static void Main(string[] args) {
            InputHandler i = new InputHandler();

            // I'm lazy
            Action<String> cw = Console.Write;
            Action<String> cwl = Console.WriteLine;

            // say some ass
            cwl("Welcome to cmd-thing.\n");

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
            i.SetFielDimensions(input1, input2);

            // display ass
            cwl(i.DrawField());

            // stop
            Console.ReadKey();
        }
    }
}
