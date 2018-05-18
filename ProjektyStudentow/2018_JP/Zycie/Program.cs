using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zycie.Dekorator;
using Zycie.Model;

namespace Zycie
{
    class Program
    {
        static void Main(string[] args)
        {
            var bog = Bog.Instance;
            bog.Swiat.ZaludnijSwiat(100, bog);

            try
            {
                var superistota = (SuperIstota)bog.Swiat.Where(i => i.GetType() == typeof(SuperIstota))?.First();

                WypiszInfo(superistota);
                superistota.PrzyjmijAtak(10, superistota);
                WypiszInfo(superistota);
                superistota.PrzyjmijAtak(10, superistota);
                WypiszInfo(superistota);
                superistota.PrzyjmijAtak(10, superistota);
                WypiszInfo(superistota);


                var czlowiek = (Czlowiek)bog.Swiat.Where(i => i.GetType() == typeof(Czlowiek))?.First();

                WypiszInfo(czlowiek);
                superistota.Atakuj(czlowiek);
                WypiszInfo(czlowiek);
                superistota.Atakuj(czlowiek);
                WypiszInfo(czlowiek);
                superistota.Atakuj(czlowiek);
                WypiszInfo(czlowiek);
            }
            catch (ZniszczonoSwiatException e)
            {
            }

        }

        private static void WypiszInfo(Istota istota)
        {
            System.Console.WriteLine("Typ: {0}", istota.GetType());
            System.Console.WriteLine("RodzajIstoty: {0}", istota.RodzajIstoty);
            System.Console.WriteLine("Nazwa: {0}", istota.Nazwa);
            System.Console.WriteLine("PunktyZycia: {0}", istota.PunktyZycia);
            System.Console.WriteLine();
        }
    }
}
