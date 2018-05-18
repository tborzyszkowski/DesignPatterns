using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zycie.Model;

namespace Zycie.Fabryka
{
    public class FabrykaOwiec:FabrykaAbstrakcyjnaIstot
    {
        private readonly string _nazwa;

        public FabrykaOwiec(string nazwa)
        {
            this._nazwa = nazwa;
        }

        public override Istota StworzIstote()
        {
            return new Owca(_nazwa);
        }
    }
}
