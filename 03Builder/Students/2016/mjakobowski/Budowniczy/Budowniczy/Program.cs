using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budowniczy
{
    class Program
    {
        static void Main(string[] args)
        {
            Sklep sklep = new Sklep();

            Statek katamaran = sklep.Buduj(new KatamaranBudowniczy());
            katamaran.Pokaz();

            sklep.Buduj(new PancernikBudowniczy()).Pokaz();

            Console.ReadKey();
        }
    }
}
