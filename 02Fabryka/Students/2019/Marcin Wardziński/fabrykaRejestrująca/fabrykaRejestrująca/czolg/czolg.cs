using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fabrykaRejestrująca.czolg
{
    public abstract class czolg
    {
        public String nazwa { get; protected set; }
        public decimal kaliber { get; protected set; }
        public int pancerz { get; protected set; }

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
