using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace builder.pojazd
{
    public class czolg
    {
        public String nazwa { get; set; }
        public decimal kaliber { get; set; }
        public int pancerz { get; set; }

        public void ostrzelaj()
        {
            Console.WriteLine(nazwa + " prowadzi ostrzał z działa " + kaliber + "mm.");
        }

        public void dostan()
        {
            Console.WriteLine(nazwa + " otrzymał trafienie, acz jego " + pancerz + "mm pancerza nic sobie z tego nie zrobilo.");
        }
    }
}
