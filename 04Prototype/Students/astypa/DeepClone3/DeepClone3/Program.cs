using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepClone3
{
    class Program
    {
        static void Main(string[] args)
        {
            //tworzymy prototyp i ustalamy stany
            Przedsiebiorstwo p = new Przedsiebiorstwo();
            p.Nazwa = "Nazwa przedsiebiorstwa";
            p.Miejscowosc = "Gdańsk";
            p.pracownik = new Pracownik();
            p.pracownik.Imie = "Jan";
            p.pracownik.Nazwisko = "Kowalski";
            p.pracownik.hobby = new Hobby();
            p.pracownik.hobby.Nazwa = "wędkarstwo";

            Przedsiebiorstwo p2 = new Przedsiebiorstwo();
            p2 = p.DeepCopy();

            Console.WriteLine();
            Console.WriteLine("Sprawdzenie hobby pracownika");
            if (Object.ReferenceEquals(p.pracownik.hobby,p2.pracownik.hobby))
                Console.WriteLine("Referencje odwołują się do tego samego obiektu");
            else
                Console.WriteLine("Referencje NIE odwołują się do tego samego obiektu");

            Console.WriteLine();
            Console.WriteLine("Sprawdzenie pracownika");
            if (Object.ReferenceEquals(p.pracownik, p2.pracownik))
                Console.WriteLine("Referencje odwołują się do tego samego obiektu");
            else
                Console.WriteLine("Referencje NIE odwołują się do tego samego obiektu");

            Console.WriteLine();
            Console.WriteLine("Sprawdzenie przedsiębiorstwa");
            if (Object.ReferenceEquals(p, p2))
                Console.WriteLine("Referencje odwołują się do tego samego obiektu");
            else
                Console.WriteLine("Referencje NIE odwołują się do tego samego obiektu");

            Console.ReadKey();
        }
    }
}
