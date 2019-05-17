using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fabrykaAbstrakcyjna.dziala
{
    public abstract class dziala
    {
        public String nazwa { get; protected set; }
        public decimal kaliber { get; protected set; }
        public int przeladowanie { get; protected set; }

        public void ostrzelaj()
        {
            Console.WriteLine(nazwa + " prowadzi ostrzał z działa " + kaliber + "mm.");
        }

        public void przeladuj()
        {
            Console.WriteLine(nazwa + " przeladowuje po strzale, za " + przeladowanie + "sec będzie gotów do strzału.");
        }
    }
}
