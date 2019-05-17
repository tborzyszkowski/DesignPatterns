using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fabrykaProsta
{
    class Program
    {
        static void Main(string[] args)
        {
            czolg.czolg poj1 = fabryka.dajFabryke().dajCzolg("Abrams");
            Console.WriteLine(poj1.dajNazwe());
            Console.WriteLine(poj1.dajPancerz());
            bwp.bwp poj2 = fabryka.dajFabryke().dajBewupa("Warior");
            Console.WriteLine(poj2.dajNazwe());
            Console.WriteLine(poj2.dajKaliber());

            licz(1000000);
            Console.ReadKey();
        }

        static void licz(int x)
        {
            Console.WriteLine();
            Console.WriteLine();
            DateTime poczatek = DateTime.Now;
            for (int y = 0; y < x; y++)
            {
                czolg.czolg poj = fabryka.dajFabryke().dajCzolg("Abrams");
            }
            DateTime koniec = DateTime.Now;
            Console.WriteLine("Czas trwania dla " + x + " obiektów wyniósł " + (koniec - poczatek));
        }
    }
}
