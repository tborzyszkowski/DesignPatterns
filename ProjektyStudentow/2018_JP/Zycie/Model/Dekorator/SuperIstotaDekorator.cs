using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zycie.Model;

namespace Zycie.Dekorator
{
     public abstract class SuperIstotaDekorator:Istota
     {
         public abstract override void PrzyjmijAtak(int punkty, IIstota istota);
         public abstract override void Atakuj(IIstota istota);
     }
}
