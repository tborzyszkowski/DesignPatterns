using System;

namespace FactoryExamples.Utilities
{
    public class Logger
    {
        public static void AddTestStep(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("***");
            Console.WriteLine(msg);
            Console.WriteLine("***");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
