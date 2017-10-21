using System;

namespace SingletonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Only one instance of Logger or it's childs is present at the runtime

            var logger = Logger.GetLoggerInstance();
            logger.Log("Normal logger");

            logger = ColorfulLogger.GetLoggerInstance();
            logger.Log("Colorful logger");

            logger = Logger.GetLoggerInstance();
            logger.Log("\n\nPress any key to exit...");

            Console.ReadKey();
        }
    }
}
