using System;
using System.Collections.Generic;
using System.Text;

namespace projekt
{
    class strategiaMontazu2 : strategiaMontazu
    {
        public override int montuj(zamowienie z, int ile)
        {
            Iodwiedzajacy monter = new odwiedzajacyWykonawca2(ile);
            z.akceptuj(monter);
            return monter.dajWynik();
        }
    }
}
