using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonExample
{
    public class Singleton
    {
        private int i = 0;
        private static Singleton instancja = null;

        public static Singleton Instancja
        {
            get
            {
                if (instancja == null)
                {
                    instancja = new Singleton();
                }
                return instancja;
            }
        }
        public void Print()
        {
            Console.WriteLine("instancja A numer {0}!", i++);
        }
    }
}
