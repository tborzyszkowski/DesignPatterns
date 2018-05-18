using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zycie.Model;

namespace Zycie.Fabryka
{
    public class FabrykaWilkow:FabrykaAbstrakcyjnaIstot
    {
        private readonly string _nazwa;

        public FabrykaWilkow(string nazwa)
        {
            this._nazwa = nazwa;
        }

        public override Istota StworzIstote()
        {
            return new Wilk(_nazwa);
        }
    }
}
