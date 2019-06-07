using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototypGleboki
{
    class Program
    {
        static void Main(string[] args)
        {
            czolg oryginal;
            czolg kopia;

            oryginal = new czolg("Abrams", new kadlub(new wieza(new dzialo(new pocisk(120, "podkalibrowy")))));
            kopia = oryginal.kopiuj();


            Console.WriteLine(oryginal.GetHashCode() == kopia.GetHashCode());
            Console.WriteLine(oryginal.kadlub.GetHashCode() == kopia.kadlub.GetHashCode());
            Console.WriteLine(oryginal.kadlub.wieza.GetHashCode() == kopia.kadlub.wieza.GetHashCode());
            Console.WriteLine(oryginal.kadlub.wieza.dzialo.GetHashCode() == kopia.kadlub.wieza.dzialo.GetHashCode());
            Console.WriteLine(oryginal.kadlub.wieza.dzialo.pocisk.GetHashCode() == kopia.kadlub.wieza.dzialo.pocisk.GetHashCode());
            Console.WriteLine(oryginal.kadlub.wieza.dzialo.pocisk.kaliber.GetHashCode() == kopia.kadlub.wieza.dzialo.pocisk.kaliber.GetHashCode());
            Console.WriteLine(oryginal.kadlub.wieza.dzialo.pocisk.kaliber == kopia.kadlub.wieza.dzialo.pocisk.kaliber);

            oryginal.kadlub.wieza.dzialo.pocisk.kaliber = 100;
            Console.WriteLine(kopia.kadlub.wieza.dzialo.pocisk.kaliber);
            Console.WriteLine(oryginal.kadlub.wieza.dzialo.pocisk.kaliber);

            Console.WriteLine(oryginal.kadlub.wieza.dzialo.pocisk.kaliber.GetHashCode() == kopia.kadlub.wieza.dzialo.pocisk.kaliber.GetHashCode());
            Console.WriteLine(oryginal.kadlub.wieza.dzialo.pocisk.kaliber == kopia.kadlub.wieza.dzialo.pocisk.kaliber);

            Console.ReadKey();
        }
    }
}
