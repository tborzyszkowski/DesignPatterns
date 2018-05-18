using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zycie.Dekorator;
using Zycie.Model;

namespace UnitTestZycie
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestOdbioruAtakuPrzezSuperIstote()
        {
            var bog = Bog.Instance;
            bog.Swiat.ZaludnijSwiat(100, bog);

            var superistota = (SuperIstota)bog.Swiat.Where(i => i is SuperIstota)?.First();

            superistota.PrzyjmijAtak(10, superistota);
            superistota.PrzyjmijAtak(10, superistota);
            superistota.PrzyjmijAtak(10, superistota);

            Assert.AreEqual(260, superistota.PunktyZycia);
        }

        [TestMethod]
        public void TestOdbioruAtakuPrzezCzlowieka()
        {
            var bog = Bog.Instance;
            bog.Swiat.ZaludnijSwiat(100, bog);

            var czlowiek = (Czlowiek)bog.Swiat.Where(i => i is Czlowiek)?.First();

            czlowiek.PrzyjmijAtak(10, czlowiek);
            czlowiek.PrzyjmijAtak(10, czlowiek);
            czlowiek.PrzyjmijAtak(10, czlowiek);

            Assert.AreEqual(20, czlowiek.PunktyZycia);
        }

        [TestMethod]
        public void TestAtaku()
        {
            var bog = Bog.Instance;
            bog.Swiat.ZaludnijSwiat(100, bog);

            var wilk = (Wilk)bog.Swiat.Where(i => i is Wilk)?.First();
            var superWilk = new SuperIstota(wilk);

            var czlowiek = (Czlowiek)bog.Swiat.Where(i => i is Czlowiek)?.First();

            superWilk.Atakuj(czlowiek);
            czlowiek.Atakuj(superWilk);

            Assert.AreEqual(40, superWilk.PunktyZycia);
            Assert.AreEqual(44, czlowiek.PunktyZycia);
        }

        [TestMethod]
        public void TestAtakuNaBoga()
        {
            var bog = Bog.Instance;
            bog.Swiat.ZaludnijSwiat(100, bog);

            var wilk = (Wilk)bog.Swiat.Where(i => i is Wilk)?.First();
            var superWilk = new SuperIstota(wilk);

            var czlowiek = (Czlowiek)bog.Swiat.Where(i => i is Czlowiek)?.First();

            superWilk.Atakuj(bog);
            czlowiek.Atakuj(bog);
            bog.Atakuj(superWilk);
            bog.Atakuj(czlowiek);

            Assert.AreEqual(Int32.MaxValue - 6 - 10, bog.PunktyZycia);
            Assert.AreEqual(false, czlowiek.CzyZyje);
            Assert.AreEqual(false, superWilk.CzyZyje);
        }
    }
}
