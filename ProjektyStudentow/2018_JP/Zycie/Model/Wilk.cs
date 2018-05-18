using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zycie.Model
{
    public sealed class Wilk:Istota
    {
        public override RodzajIstoty RodzajIstoty => RodzajIstoty.Czlowiek;

        public Wilk(string nazwa)
        {
            Nazwa = nazwa;
            PunktyZycia = 30;
            PunktyAkcji = 3;
        }
    }
}
