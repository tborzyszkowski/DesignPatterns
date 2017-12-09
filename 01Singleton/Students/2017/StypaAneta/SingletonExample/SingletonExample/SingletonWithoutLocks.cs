using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonExample
{
    //od razu przy deklaracji inicjalizujemy obiekt
    public sealed class SingletonWithoutLocks
    {
        private static readonly SingletonWithoutLocks instance = new SingletonWithoutLocks();
        private int ile = 0;

        static SingletonWithoutLocks()
        {
        }

        public static SingletonWithoutLocks Instance
        {
            get
            {
                return instance;
            }
        }

        public void Print()
        {
            Console.WriteLine("Hello World po raz {0}!", ile++);
        }

        private SingletonWithoutLocks()
        {
            ile = 1;
        }
    }
}
