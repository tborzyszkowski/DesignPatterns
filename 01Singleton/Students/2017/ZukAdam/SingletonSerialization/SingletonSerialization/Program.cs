using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating new instance of logger, setting up new background color and serializing for test purposes
            var logger = Logger.GetLoggerInstance() as Logger;
            logger.BackColor = ConsoleColor.Red;

            logger.Serialize("Logger.xml");


        }
    }
}
