using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            SzablonProxy proxy = new SzablonProxy();

            Console.WriteLine(proxy.Przepros("Michał", "wyzwiska"));
            Console.WriteLine(proxy.Popros("Mamo", "pieniądze"));
            Console.WriteLine(proxy.Pozdrow("Grecji"));
            Console.WriteLine(proxy.Zyczenia("Karolina"));

            Console.ReadKey();


        }
    }
}
