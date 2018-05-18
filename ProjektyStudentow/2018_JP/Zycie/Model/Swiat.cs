using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zycie.Dekorator;
using Zycie.Fabryka;

namespace Zycie.Model
{
    public class Swiat : IEnumerable<Istota>
    {
        public static string[] ImionaLudzi = new[] { "Adam", "Ewa", "Karol", "Filip", "Mikolaj", "Karolina", "Magda", "Jan" };
        public static string[] ImionaZwierzat = new[] { "KK", "FF", "SS", "WW", "VV", "BB", "XX", "OO", "PP", "LK" };
        private static Random Rnd = new Random();
        private IObserwator _obserwator;

        private List<Istota> Istoty = new List<Istota>();

        public Istota StworzCzlowieka()
        {
            var czlowiek = FabrykaIstot.DajIstote(new FabrykaLudzi(ImionaLudzi[Rnd.Next(ImionaLudzi.Length)]));
            Istoty.Add(czlowiek);
            czlowiek.DodajObserwatora(_obserwator);
            return czlowiek;
        }

        public Istota StworzOwce()
        {
            var owca = FabrykaIstot.DajIstote(new FabrykaOwiec(ImionaZwierzat[Rnd.Next(ImionaZwierzat.Length)]));
            Istoty.Add(owca);
            owca.DodajObserwatora(_obserwator);
            return owca;
        }

        public Istota StworzWilka()
        {
            var wilk = FabrykaIstot.DajIstote(new FabrykaWilkow(ImionaZwierzat[Rnd.Next(ImionaZwierzat.Length)]));
            Istoty.Add(wilk);
            wilk.DodajObserwatora(_obserwator);
            return wilk;
        }

        public Istota StworzSuperCzlowieka()
        {
            var czlowiek = new SuperIstota(FabrykaIstot.DajIstote(new FabrykaLudzi(ImionaLudzi[Rnd.Next(ImionaLudzi.Length)])));
            Istoty.Add(czlowiek);
            czlowiek.DodajObserwatora(_obserwator);
            return czlowiek;
        }

        public void ZaludnijSwiat(int iloscIstot, IObserwator obserwator)
        {
            this._obserwator = obserwator;
            while (iloscIstot > 0)
            {
                switch (iloscIstot % 4)
                {
                    case 0:
                        StworzCzlowieka();
                        break;
                    case 1:
                        StworzOwce();
                        break;
                    case 2:
                        StworzWilka();
                        break;
                    case 3:
                        StworzSuperCzlowieka();
                        break;
                }
                iloscIstot -= 1;
            }
        }

        public void ZniszczIstoty()
        {
            Istoty.Clear();
        }

        public IEnumerator<Istota> GetEnumerator()
        {
            for (int index = 0; index < Istoty.Count; index++)
            {
                yield return Istoty[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
