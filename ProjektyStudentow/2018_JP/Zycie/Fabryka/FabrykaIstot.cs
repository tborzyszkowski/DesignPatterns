using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zycie.Model;

namespace Zycie.Fabryka
{
    public static class FabrykaIstot
    {
        public static Istota DajIstote(FabrykaAbstrakcyjnaIstot fabrykaAbstrakcyjnaIstot)
        {
            return fabrykaAbstrakcyjnaIstot.StworzIstote();
        }
    }
}
