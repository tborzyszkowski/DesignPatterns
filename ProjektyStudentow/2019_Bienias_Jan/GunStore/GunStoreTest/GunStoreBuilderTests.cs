using GunStore.Builder;
using GunStore.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GunStoreTest
{
    [TestClass]
    public class GunStoreBuilderTests
    {
        [TestMethod]
        public void AK47FluentBuilderSetsUpParamsCorrectly()
        {
            var gunFactory = GunFactory.Instance;
            var ak = gunFactory.Construct(new AK47Builder());
            Assert.AreEqual(ak.Name, "AK-47");
            Assert.AreEqual(ak.Type, GunType.Rifle);
            Assert.AreEqual(ak.Nation, Nation.USSR);
            Assert.AreEqual(ak.BasePrice, 2699.99m);
            Assert.AreEqual(ak.Designer, "Mikhail Kalashnikov");
            Assert.AreEqual(ak.Manufacturer, "Kalashnikov Concern");
            Assert.AreEqual(ak.MuzzleVelocity, 715);
            Assert.AreEqual(ak.RateOfFire, 600);
            Assert.AreEqual(ak.Caliber, "7.62 mm");
            Assert.AreEqual(ak.Mass, 3.47m);
        }

        [TestMethod]
        public void M1911FluentBuilderSetsUpParamsCorrectly()
        {
            var gunFactory = GunFactory.Instance;
            var m1991 = gunFactory.Construct(new M1911Builder());
            Assert.AreEqual(m1991.Name, "Colt M1911");
            //...
        }

        [TestMethod]
        public void M870FluentBuilderSetsUpParamsCorrectly()
        {
            var gunFactory = GunFactory.Instance;
            var m870 = gunFactory.Construct(new M870Builder());
            Assert.AreEqual(m870.Name, "Remington M870");
            //...
        }

        [TestMethod]
        public void MP5FluentBuilderSetsUpParamsCorrectly()
        {
            var gunFactory = GunFactory.Instance;
            var mp5 = gunFactory.Construct(new MP5Builder());
            Assert.AreEqual(mp5.Name, "HK MP5");
            //...
        }
    }
}
