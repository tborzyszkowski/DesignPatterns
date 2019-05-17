using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fabrykaRefleksyjna
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var fabryczka = fabryka.dajFabryke();

            fabryczka.twozenieSlownika();

            czolg.czolg poj1 = fabryczka.zrobCzolg("Abrams");
            poj1.dostan();
            poj1.ostrzelaj();
            apc.apc poj2 = fabryczka.zrobTransporter("Rosomak");
            poj2.ostrzelaj();
            poj2.wyzadzDesant();
            bwp.bwp poj3 = fabryczka.zrobBewupa("Darlo");
            poj3.ostrzelaj();
            poj3.przełam();
            dziala.dziala poj4 = fabryczka.zrobDzialo("Dana");
            poj4.ostrzelaj();
            poj4.przeladuj();
            */

            licz(1000000);
            Console.ReadKey();
        }

        static void licz(int x)
        {
            Console.WriteLine();
            Console.WriteLine();
            DateTime poczatek = DateTime.Now;
            fabryka.dajFabryke().twozenieSlownika();
            for (int y = 0; y < x; y++)
            {
                czolg.czolg poj = fabryka.dajFabryke().zrobCzolg("Abrams");
            }
            DateTime koniec = DateTime.Now;
            Console.WriteLine("Czas trwania dla " + x + " obiektów wyniósł " + (koniec - poczatek));
        }
    }
}
