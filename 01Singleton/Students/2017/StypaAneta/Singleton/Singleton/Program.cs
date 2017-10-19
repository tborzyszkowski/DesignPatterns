using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Program
    {
        public static void Main(string[] args)
        {
            People p1 = new People();
            p1.name = "Jan";
            p1.lastname = "Kowalski";

            var logger = Logger.Instance();
            logger.Log(p1);

            logger = ProgramTest.Instance();
            logger.Log(p1);

            Lock.Instance.Log(p1);
        
            Console.WriteLine("END");
            Console.ReadKey();
        }
    }
}