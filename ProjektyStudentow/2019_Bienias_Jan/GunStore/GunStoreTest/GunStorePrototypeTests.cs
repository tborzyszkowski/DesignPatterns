using GunStore;
using GunStore.Builder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GunStoreTest
{
    [TestClass]
    public class GunStorePrototypeTests
    {
        private Gun gun;
        private Gun clonedGun;

        [TestInitialize]
        public void Initialize()
        {
            gun = GunFactory.Instance.Construct(new AK47Builder());
            clonedGun = gun.Clone();
        }

        [TestMethod]
        public void GunAndClonedGunAreNotSame()
        {
            Assert.AreNotSame(gun, clonedGun);
        }

        [TestMethod]
        public void GunAndClonedGunHaveEqualFields()
        {
            Assert.AreEqual(gun.Name, clonedGun.Name);
            Assert.AreEqual(gun.Type, clonedGun.Type);
            Assert.AreEqual(gun.Nation, clonedGun.Nation);
            Assert.AreEqual(gun.BasePrice, clonedGun.BasePrice);
            Assert.AreEqual(gun.Designer, clonedGun.Designer);
            Assert.AreEqual(gun.Manufacturer, clonedGun.Manufacturer);
            Assert.AreEqual(gun.MuzzleVelocity, clonedGun.MuzzleVelocity);
            Assert.AreEqual(gun.RateOfFire, clonedGun.RateOfFire);
            Assert.AreEqual(gun.Caliber, clonedGun.Caliber);
            Assert.AreEqual(gun.Mass, clonedGun.Mass);
        }

        [TestCleanup]
        public void Cleanup()
        {
            gun = null;
            clonedGun = null;
        }
    }
}
