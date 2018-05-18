using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zycie.Model
{
    public abstract class Istota:IIstota, IObserwowany
    {
        public virtual string Nazwa { get; set; }
        public abstract RodzajIstoty RodzajIstoty { get;}
        public virtual int PunktyZycia { get; set; }
        public virtual int PunktyAkcji { get; set; }
        public virtual bool CzyZyje => PunktyZycia > 0;

        private readonly List<IObserwator> _obserwatorzy = new List<IObserwator>();

        public virtual void PrzyjmijAtak(int punkty, IIstota istota)
        {
            this.PunktyZycia -= punkty;
            if (this.PunktyZycia < 0)
                this.PunktyZycia = 0;
            PowiadomObserwatorow(istota);
        }

        public virtual void Atakuj(IIstota istota)
        {
            istota.PrzyjmijAtak(this.PunktyAkcji, this);
        }

        public void DodajObserwatora(IObserwator o)
        {
            _obserwatorzy.Add(o);
        }

        public void UsunObserwator(IObserwator o)
        {
            _obserwatorzy.Remove(o);
        }

        public void PowiadomObserwatorow(IIstota istota)
        {
            _obserwatorzy.ForEach(o => o.PoinformujOAtaku(istota,this));
        }
    }
}
