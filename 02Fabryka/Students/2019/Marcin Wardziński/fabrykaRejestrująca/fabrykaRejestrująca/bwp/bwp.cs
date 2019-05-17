using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fabrykaRejestrująca.bwp
{
    public abstract class bwp
    {
        public String nazwa { get; protected set; }
        public decimal kaliber { get; protected set; }
        public int mocSilnika { get; protected set; }

        public void ostrzelaj()
        {
            Console.WriteLine(nazwa + " prowadzi ostrzał z działa " + kaliber + "mm.");
        }

        public void przełam()
        {
            Console.WriteLine(nazwa + " przeprowadza uderzenie przełamujace, korzystając ze swoich " + mocSilnika + "koni mocy.");
        }
    }
}
