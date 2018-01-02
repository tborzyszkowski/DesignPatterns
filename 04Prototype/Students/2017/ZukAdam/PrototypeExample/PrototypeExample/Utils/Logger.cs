using System;

namespace PrototypeExample.Utils
{
    public class Logger
    {
        public static void Log(string testName)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;

            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine(testName.ToUpper());
            Console.WriteLine("-----------------------------------------------------\n");

            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
