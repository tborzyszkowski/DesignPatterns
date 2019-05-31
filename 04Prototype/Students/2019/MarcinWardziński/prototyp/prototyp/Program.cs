using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototyp
{
    class Program
    {
        static void Main(string[] args)
        {
            czolg oryginal;
            czolg kopia;

            oryginal = new czolg("Abrams", new wieza(new dzialo(120, 27)));
            kopia = oryginal.kopiuj();


            Console.WriteLine(oryginal.GetHashCode()==kopia.GetHashCode());
            Console.WriteLine(oryginal.nazwa.GetHashCode() == kopia.nazwa.GetHashCode());
            Console.WriteLine(oryginal.wieza.GetHashCode() == kopia.wieza.GetHashCode());
            Console.WriteLine(oryginal.wieza.dzialo.GetHashCode() == kopia.wieza.dzialo.GetHashCode());
            Console.WriteLine(oryginal.wieza.dzialo.kaliber.GetHashCode() == kopia.wieza.dzialo.kaliber.GetHashCode());

            Console.ReadKey();

        }
    }
}
