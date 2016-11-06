using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabrykaRefleksja
{
    public class Audi : Car
    {
        public Audi()
        {
            Producent = "Audi";
            Model = "A3";
            PojemnoscSilnika = 1.6;
            Wlasciwosci.Add("LPG");
            Wlasciwosci.Add("Manual gearbox");
        }
    }
}
