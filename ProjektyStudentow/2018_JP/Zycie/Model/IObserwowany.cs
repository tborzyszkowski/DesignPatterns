using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zycie.Model
{
    public interface IObserwowany
    {
        void DodajObserwatora(IObserwator o);
        void UsunObserwator(IObserwator o);
        void PowiadomObserwatorow(IIstota istota);
    }
}
