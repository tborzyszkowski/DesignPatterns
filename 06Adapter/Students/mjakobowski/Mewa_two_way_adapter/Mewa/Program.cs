using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mewa
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n---------------- Proejkt1: Kaczka. ----------------");
            Console.WriteLine("Eksperyment 1: Testujemy silniki samolotu");
            ISamolot samolot = new Samolot();
            samolot.Startowanie();
            if (samolot.WPowietrzu) Console.WriteLine("Silniki samolotu są w porządku, lot na wysokości: " + samolot.Wysokość + " metrów.");

            //klasyczne uzycie adaptera
            Console.WriteLine("\nEksperyment 2: Użycie silników w trybie wodnym");
            ISamolot mewa = new Mewa();
            mewa.Startowanie(); // od razu zwiększa obroty
            Console.WriteLine("Mewa wystartowała");

            

            //dwustronny adapter: uzycie instrukcji Statku na obiekcie ISamolot (nie ma ich w interfejsie ISamolot)
            Console.WriteLine("\nEksperyment 3: Zwiększenie prędkości Mewy:");
            (mewa as IStatek).ZwiększObroty();
            (mewa as IStatek).ZwiększObroty();
            if (mewa.WPowietrzu)
                Console.WriteLine("Mewa leci na wysokości " + mewa.Wysokość + " m n.p.m oraz z prędkością " + (mewa as IStatek).Prędkość + " węzłów");
            Console.WriteLine("\nProjekt Mewa zakończony pełnym sukcesem; Mewa potrafi latać!");

            Console.WriteLine("\n\n---------------- Projekt2: Dzika kaczka. ----------------");
            //uzycie adaptera
            Console.WriteLine("Eksperyment 4: Użycie silników Kaczki w trybie wodnym");
            IStatek kaczka = new Kaczka();
            (kaczka as ISamolot).Startowanie(); // od razu zwiększa obroty
            Console.WriteLine("Kaczka wystartowała");

            Console.WriteLine("\nEksperyment 5: Zwiększenie prędkości Kaczki:");
            kaczka.ZwiększObroty();
            kaczka.ZwiększObroty();
            if ((kaczka as ISamolot).WPowietrzu)
                Console.WriteLine("Kaczka leci na wysokości " + (kaczka as ISamolot).Wysokość + " m n.p.m oraz z prędkością " + kaczka.Prędkość + " węzłów");
            Console.WriteLine("\nEkperyment Kaczka pełnym sukcesem; Mewa potrafi latać!");

            Console.ReadKey();
        }
    }
}
