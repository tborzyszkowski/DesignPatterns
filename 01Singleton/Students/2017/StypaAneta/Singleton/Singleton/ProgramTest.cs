using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class ProgramTest : Logger
    {
        private ProgramTest() { }

        public new static Logger Instance()
        {
            if (instance == null || instance.GetType() != typeof(ProgramTest))
            {
                instance = new ProgramTest();
            }
            return instance;
        }

        public override void Log(People p1)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(p1.lastname + " " + p1.name);
    
        }
    }
}
