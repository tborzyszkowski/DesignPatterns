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

            for (int ile = 0; ile < 10; ++ile)
            {
                Console.WriteLine("Iteracja {0}", ile + 1);
                Singleton.Instance.Print();
                SingletonSecured.Instance.Print();
                SingletonWithoutLocks.Instance.Print();
            }
            Console.ReadKey();
        }
    }
}
