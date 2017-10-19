using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Logger : ILogger
    {
        protected static Logger instance;

        protected Logger() { }
        public static Logger Instance()
        {
            if (instance == null || instance.GetType() != typeof(Logger))
            {
                instance = new Logger();
            }
            return instance;
        }

        public virtual void Log(People p1)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(p1.name + " " + p1.lastname);
        }
    }
}