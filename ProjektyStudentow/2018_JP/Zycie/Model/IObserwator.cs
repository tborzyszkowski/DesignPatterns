using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zycie.Model
{
    public interface IObserwator
    {
        void PoinformujOAtaku(IIstota atakujacy, IIstota odbierajacyAtak);
    }
}
