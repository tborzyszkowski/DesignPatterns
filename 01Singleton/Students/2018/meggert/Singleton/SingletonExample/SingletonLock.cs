using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonExample
{

    public sealed class SingletonLock
    {
        private int i = 0;
        private static SingletonLock instancja = null;
        private static readonly object o = new object();

        public static SingletonLock Instancja
        {
            get
            {
                lock (o)
                {
                    if (instancja == null)
                    {
                        instancja = new SingletonLock();
                    }
                    return instancja;
                }
            }
        }
        public void Print()
        {
            Console.WriteLine("instancja B numer {0}!", i++);
        }
    }
}
