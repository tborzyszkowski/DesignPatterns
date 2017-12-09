using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonExample
{
    //wykorzystanie lock
    //oznacza część krytyczną kodu która zablokuje przepływ kodu dla innych wątków aż do jej zwolnienia
    //wew. czesci krytycznej zabezpieczamy kod, który mogly zachowac sie nieprzewidywanie gdyby wiele watkow na
    //raz probowalo dostac sie do jednej i tej samej funkcjonalnosci

    public sealed class SingletonSecured
    {
        private static SingletonSecured instance = null;
        private static readonly object obj = new object();
        private int ile = 0;

        public static SingletonSecured Instance
        {
            get
            {
                lock (obj)
                {
                    if (instance == null)
                    {
                        instance = new SingletonSecured();
                    }
                    return instance;
                }
            }
        }

        public void Print()
        {
            Console.WriteLine("Hello World po raz {0}!", ile++);
        }

        private SingletonSecured()
        {
            ile = 1;
        }
    }
}
