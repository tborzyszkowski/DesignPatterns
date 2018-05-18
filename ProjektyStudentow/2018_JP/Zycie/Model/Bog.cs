using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zycie.Fabryka;

namespace Zycie.Model
{
    public sealed class Bog:Istota, IObserwator
    {
        public override RodzajIstoty RodzajIstoty => RodzajIstoty.Bog;
        private static readonly Lazy<Bog> lazy =
            new Lazy<Bog>(() => new Bog());

        public static Bog Instance { get { return lazy.Value; } }
        public Swiat Swiat;
        public static int IloscPowiadomien = 0;  
        private Bog()
        {
            Nazwa = "Bóg";
            PunktyAkcji = 10000;
            PunktyZycia = Int32.MaxValue;
            Swiat = new Swiat();
        }


        public void PoinformujOAtaku(IIstota atakujacy, IIstota odbierajacyAtak)
        {
            System.Console.WriteLine("Boże, Ja {1} jestem atakowany przez {0}." , atakujacy.Nazwa, odbierajacyAtak.Nazwa);
            IloscPowiadomien += 1;

            if (IloscPowiadomien > 5)
                ZniszczSwiat();
        }

        private void ZniszczSwiat()
        {
            Swiat.ZniszczIstoty();
            Swiat = null;
            IloscPowiadomien = 0;
            throw new ZniszczonoSwiatException("By by!");
        }
    }
}
