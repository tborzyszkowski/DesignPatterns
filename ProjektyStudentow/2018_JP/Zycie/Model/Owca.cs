using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zycie.Model
{
    public sealed class Owca:Istota
    {
        public override RodzajIstoty RodzajIstoty => RodzajIstoty.Owca;

        public Owca(string nazwa)
        {
            Nazwa = nazwa;
            PunktyZycia = 10;
            PunktyAkcji = 1;
        }
    }
}
