using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budowniczy
{
    class Statek
    {
        private string rodzajStatku;
        private Dictionary<string, string> czesci = new Dictionary<string, string>();

        // konstruktor
        public Statek(string rodzajStatku)
        {
            this.rodzajStatku = rodzajStatku;
        }
        // indeksator z akcesorami
        public string this[string klucz]
        {
            get { return czesci[klucz]; }
            set { czesci[klucz] = value; }
        }

        public void Pokaz()
        {
            Console.WriteLine("\n--------------------");
            Console.WriteLine("Rodzaj statku:  {0}", rodzajStatku);
            Console.WriteLine("Kadlub statku:  {0}", czesci["kadlub"]);
            Console.WriteLine("Silnik:      {0}", czesci["silnik"]);
            Console.WriteLine("Ster:        {0}", czesci["ster"]);
            Console.WriteLine("Wyposazenie: {0}", czesci["wyposazenie"]);
        }
    }
}
