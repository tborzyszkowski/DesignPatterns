using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace fabrykaAbstrakcyjna
{
    class Program
    {
        static void Main(string[] args)
        {

            czolg.czolg poj1 = fabrykaEU.dajFabryke().zrobCzolg();
            poj1.ostrzelaj();
            poj1.dostan();

            bwp.bwp poj2 = fabrykaUS.dajFabryke().zrobBwp();
            poj2.ostrzelaj();
            poj2.przełam();


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
                czolg.czolg poj = fabrykaEU.dajFabryke().zrobCzolg();
            }
            DateTime koniec = DateTime.Now;
            Console.WriteLine("Czas trwania dla " + x + " obiektów wyniósł " + (koniec - poczatek));      
        }
    }
}
