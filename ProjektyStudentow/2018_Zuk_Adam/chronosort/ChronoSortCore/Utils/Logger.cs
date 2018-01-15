using ChronoSortCore.Interfaces;
using System;

namespace ChronoSortCore.Utils
{
    public class Logger : ILogger
    {
        protected static Logger LoggerInstance;

        protected Logger() { }

        public static Logger GetLoggerInstance()
        {
            if (LoggerInstance == null || LoggerInstance.GetType() != typeof(Logger))
            {
                LoggerInstance = new Logger();
            }
            return LoggerInstance;
        }

        public virtual void Error(string text)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(text);

            Console.ResetColor();
        }

        public virtual void Info(string text)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(text);

            Console.ResetColor();
        }

        public virtual void Warning(string text)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);

            Console.ResetColor();
        }
    }
}
