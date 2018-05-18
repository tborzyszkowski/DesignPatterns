using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zycie.Model
{
    public interface IIstota
    {
        string Nazwa { get; set; }
        RodzajIstoty RodzajIstoty { get; }
        int PunktyZycia { get; set; }
        int PunktyAkcji { get; set; }
        bool CzyZyje { get;}
        void PrzyjmijAtak(int punkty, IIstota istota);
        void Atakuj(IIstota istota);
    }
}
