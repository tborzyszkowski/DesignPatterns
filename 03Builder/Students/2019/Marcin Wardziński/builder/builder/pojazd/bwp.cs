using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace builder.pojazd
{
    public class bwp
    {
        public String nazwa { get; set; }
        public decimal kaliber { get; set; }
        public int desant { get; set; }

        public void ostrzelaj()
        {
            Console.WriteLine(nazwa + " prowadzi ostrzał z działa " + kaliber + "mm.");
        }

        public void desantuj()
        {
            Console.WriteLine(nazwa + " wyładował oddział szturmowy w liczbie " + desant + " żołnierzy.");
        }
    }
}
