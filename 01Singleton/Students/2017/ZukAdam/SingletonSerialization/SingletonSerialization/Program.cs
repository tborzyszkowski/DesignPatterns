using System;
using System.Threading;

namespace SingletonSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
        }

        private static void Test()
        {
            Prepare();

            var thread1 = new Thread(() =>
            {
                Logger.Deserialize("Logger1.xml");

                var logger = Logger.GetLoggerInstance();
                logger.Log("This text should looks the same like this one below...");
            });
            var thread2 = new Thread(() =>
            {
                Logger.Deserialize("Logger2.xml");

                var logger = Logger.GetLoggerInstance();
                logger.Log("This text should looks the same like this one above...");
            });

            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();

            Console.ReadKey();
        }

        private static void Prepare()
        {
            // Creating new instance of logger, setting up new background color and serializing for test purposes
            var logger = Logger.GetLoggerInstance() as Logger;
            logger.BackColor = ConsoleColor.Red;

            logger.Serialize("Logger1.xml");

            logger.BackColor = ConsoleColor.Yellow;

            logger.Serialize("Logger2.xml");

            Logger.DropInstance();
        }
    }
}
