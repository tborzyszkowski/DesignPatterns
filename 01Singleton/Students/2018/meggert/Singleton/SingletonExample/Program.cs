using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonExample
{
 
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Singleton.Instancja.Print();
                SingletonLock.Instancja.Print();
            }
            Console.ReadKey();
        }
    }
}
