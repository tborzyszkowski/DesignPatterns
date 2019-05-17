using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using builder.pojazd;

namespace builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var fabryka = new fabrykaCzolgow();
            czolg poj1 = fabryka.zbuduj(new builderAbrams());
            poj1.dostan();
            poj1.ostrzelaj();
            czolg poj2 = fabryka.zbuduj(new builderMerkava());
            poj2.dostan();
            poj2.ostrzelaj();

            var fabryka2 = new fabrykaBewupow();
            bwp poj3 = fabryka2.zbuduj(new builderRosomak());
            poj3.desantuj();
            poj3.ostrzelaj();
            bwp poj4 = fabryka2.zbuduj(new builderStriker());
            poj4.desantuj();
            poj4.ostrzelaj();

            //licz(10000);
            Console.ReadKey();
        }

        static void licz(int x)
        {
            Console.WriteLine();
            Console.WriteLine();
            DateTime poczatek = DateTime.Now;
            var fabryka = new fabrykaCzolgow();
            for (int y = 0; y < x; y++)
            {
                czolg poj = fabryka.zbuduj(new builderAbrams());
            }
            DateTime koniec = DateTime.Now;
            Console.WriteLine("Czas trwania dla " + x + " obiektów wyniósł " + (koniec - poczatek));
        }
    }
}
