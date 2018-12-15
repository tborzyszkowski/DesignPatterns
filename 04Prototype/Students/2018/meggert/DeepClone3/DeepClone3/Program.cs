using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protype2
{
    class Program
    {
        static void Main(string[] args)
        {
            Marka p = new Marka();
            p.Nazwa = "HPI";
            p.samochod = new Samochod();
            p.samochod.Model = "Bullet";
            p.samochod.Bateria = "2S";
            p.samochod.silnik = new Silnik();
            p.samochod.silnik.Typ = "bezszczotkowy";
            Marka p2 = new Marka();
            p2 = p.DeepCopy();
            if (Object.ReferenceEquals(p.samochod.silnik,p2.samochod.silnik))
                Console.WriteLine("ten sam obiekt");
            else
                Console.WriteLine("inny obiekt");

            if (Object.ReferenceEquals(p.samochod, p2.samochod))
                Console.WriteLine("ten sam obiekt");
            else
                Console.WriteLine("inny obiekt");

            if (Object.ReferenceEquals(p, p2))
                Console.WriteLine("ten sam obiekt");
            else
                Console.WriteLine("inny obiekt");
            Console.ReadKey();
        }
    }
}
