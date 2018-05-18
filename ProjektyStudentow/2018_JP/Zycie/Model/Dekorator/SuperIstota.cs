using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zycie.Model;

namespace Zycie.Dekorator
{
    public class SuperIstota:SuperIstotaDekorator
    {
        protected Istota Istota;

        public SuperIstota(Istota Istota)
        {
            this.Istota = Istota;
        }

        public override void PrzyjmijAtak(int punkty, IIstota istota)
        {
            this.Istota.PrzyjmijAtak(punkty, istota);
            this.Istota.PunktyZycia *= 2;
        }

        public override void Atakuj(IIstota istota)
        {
            this.Istota.Atakuj(istota);
            this.Istota.Atakuj(istota);
        }

        public override int PunktyZycia
        {
            get { return Istota.PunktyZycia; }
            set { Istota.PunktyZycia = value; }
        }

        public override int PunktyAkcji
        {
            get { return Istota.PunktyAkcji; }
            set { Istota.PunktyAkcji = value; }
        }

        public override string Nazwa
        {
            get { return Istota.Nazwa; }
            set { Istota.Nazwa = value; }
        }

        public override RodzajIstoty RodzajIstoty
        {
            get { return Istota.RodzajIstoty; }
        }
        
        public override bool CzyZyje => Istota.PunktyZycia > 0;
    }
}
