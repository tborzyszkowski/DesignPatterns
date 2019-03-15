using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var log1 = logerMlody1.dajLogera;
            var log2 = logerMlody2.dajLogera;

            log1.loguj();
            log1.okresl();
            log2.loguj();
            log2.okresl();

            Console.ReadKey();
           
        }       

    }
}
