using System;
using System.Threading;

namespace SingletonSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating new instance of logger, setting up new background color and serializing for test purposes
            var logger = Logger.GetLoggerInstance() as Logger;
            logger.BackColor = ConsoleColor.Red;

            logger.Serialize("Logger1.xml");

            logger.BackColor = ConsoleColor.Yellow;

            logger.Serialize("Logger2.xml");

            // Deleting Logger instance
            Logger.DropInstance();


            // Creating and running threads - the thread that was started first will deserialize the logger from file
            var thread1 = new Thread(() => logger = Logger.GetLoggerInstance("Logger1.xml") as Logger);
            var thread2 = new Thread(() => logger = Logger.GetLoggerInstance("Logger2.xml") as Logger);

            thread1.Start();           
            thread2.Start();
            thread1.Join();
            thread2.Join();

            logger.Log("It should be written on red background...");

            Console.ReadKey();
        }
    }
}
