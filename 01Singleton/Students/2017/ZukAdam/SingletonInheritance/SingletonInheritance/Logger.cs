using System;
using SingletonTest.Interfaces;

namespace SingletonTest
{
    public class Logger : ILogger
    {
        protected static Logger LoggerInstance;

        protected Logger() {}

        public static Logger GetLoggerInstance()
        {
            if (LoggerInstance == null || LoggerInstance.GetType() != typeof(Logger))
            {
                LoggerInstance = new Logger();
            }
            return LoggerInstance;
        }

        public virtual void Log(string text)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(text);
        }
    }
}
