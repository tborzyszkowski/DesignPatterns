using System;
using System.Collections.Generic;

namespace fabryka
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IDinoFactory> Dinusie = new List<IDinoFactory>();
            Dinusie.Add(new ArchaeopteryxFactory());
            Dinusie.Add(new BrontosaurusFactory());
            Dinusie.Add(new TyranosaurusFactory());
            string imie = String.Empty;
            foreach(var Dino in Dinusie)
            {
                Console.WriteLine("Podaj imie tworzonego dinozaura: ");
                imie = Console.ReadLine();
                var GotowyDino = Dino.StworzDino(imie);
                Console.WriteLine("Stworzono:  {0}\nImie:      {1}\nEpoka:     {2}\nOdgłos:    {3}\n", 
                    GotowyDino.Gatunek, GotowyDino.Imie, GotowyDino.Epoka, GotowyDino.Odlgos);
            }
            Console.ReadKey();
        }
    }
}
