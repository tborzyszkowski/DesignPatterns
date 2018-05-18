using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zycie.Dekorator;

namespace Zycie.Model
{
    public sealed class Czlowiek:Istota
    {
        public override RodzajIstoty RodzajIstoty => RodzajIstoty.Czlowiek;

        public Czlowiek(string nazwa)
        {
            Nazwa = nazwa;
            PunktyZycia = 50;
            PunktyAkcji = 10;
        }

    }
}
