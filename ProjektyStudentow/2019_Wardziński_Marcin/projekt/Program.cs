using System;
using System.Collections.Generic;

namespace projekt
{
    class Program
    {
        public static List<zamowienie> zamowienia;
        static void Main(string[] args)
        {
            string nazwa;
            int ile;
            posrednik p = new posrednik();
            Console.WriteLine("Witaj w fabryce czołgów wardasza");
            while (true)
            {
                menu();
                int wybor = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (wybor)
                {
                    case 1:
                        Console.WriteLine("Podaj nazwę zamówienia");
                        nazwa = Console.ReadLine();
                        Console.WriteLine("Ile czołgów chcesz zamówić");
                        ile = Convert.ToInt32(Console.ReadLine());
                        p.zamowienie(nazwa, ile);
                        break;
                    case 2:
                        Console.WriteLine("Podaj nazwę zamówienia w którym chcesz pracować");
                        nazwa = Console.ReadLine();
                        Console.WriteLine("Ile zestawów części chcesz użyć");
                        ile = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Jak chcesz montować czołgi");
                        Console.WriteLine("1-Wszystkie po równo");
                        Console.WriteLine("2-Pierwszy do końca, potem drugi");
                        int typ = Convert.ToInt32(Console.ReadLine());
                        if (typ == 1 || typ == 2)
                        {
                            p.praca(nazwa, ile, typ);
                        }
                        else
                        {
                            Console.WriteLine("Podano zły typ");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Ile zestawów części chcesz dostarczyć");
                        ile = Convert.ToInt32(Console.ReadLine());
                        p.dostawa(ile);
                        break;
                    case 4:
                        p.kontrola();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Niezrozumiano polecenia");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        static void menu()
        {
            Console.WriteLine("Co chcesz zrobić? (wpisz cyfrę)");
            Console.WriteLine("1-Złóż zamówienie");
            Console.WriteLine("2-Wykonaj pracę");
            Console.WriteLine("3-Dostarcz części do magazyny");
            Console.WriteLine("4-Sprawdź poziom części w magazynie");
            Console.WriteLine("0-zamknij program");
        }
    }
}
