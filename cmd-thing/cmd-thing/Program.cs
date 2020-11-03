using cmd_thing.Logic;
using System;

namespace cmd_thing {
    class Program {
        static void Main(string[] args) {
            InputHandler i = new InputHandler();
            const int ConsoleHeight = 30;

            // I'm lazy
            Action<String> cw = Console.Write;
            Action<String> cwl = Console.WriteLine;

            // say some ass
            cwl("Welcome to cmd-thing.\n");

            // read inputs
            Console.ForegroundColor = ConsoleColor.Gray;
            cw("Height: ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            cw(ConsoleHeight+"\n");
            String input1 = ConsoleHeight+"";
            Console.ForegroundColor = ConsoleColor.Gray;
            cw("Width: ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            String input2 = Console.ReadLine();

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
            cw(i.DrawField(input1, input2));

            // stop
            Console.ReadKey();
        }
    }
}
