using GunStore;
using GunStore.Builder;
using GunStore.Decorator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GunStoreTest
{
    [TestClass]
    public class GunStoreDecoratorTests
    {
        private AbstractGun gun;

        [TestInitialize]
        public void Initialize()
        {
            gun = GunFactory.Instance.Construct(new AK47Builder());
        }

        [TestMethod]
        public void AddSilencer()
        {
            gun = new Silencer(gun);
            Assert.IsTrue(gun.ToString().Contains("Silencer") && gun.Value() > gun.BasePrice);
        }

        [TestMethod]
        public void AddHolographicSight()
        {
            gun = new HoloSight(gun);
            Assert.IsTrue(gun.ToString().Contains("Holographic sight") && gun.Value() > gun.BasePrice);
        }

        [TestMethod]
        public void AddLaserSight()
        {
            gun = new LaserSight(gun);
            Assert.IsTrue(gun.ToString().Contains("Laser sight") && gun.Value() > gun.BasePrice);
        }

        [TestMethod]
        public void AddMultipleAttachments()
        {
            gun = new LaserSight(gun);
            gun = new HoloSight(gun);
            gun = new Silencer(gun);
            Assert.IsTrue(gun.ToString().Contains("Laser sight")
                && gun.ToString().Contains("Holographic sight")
                && gun.ToString().Contains("Silencer")
                && gun.Value() > gun.BasePrice);
        }


        [TestCleanup]
        public void Cleanup()
        {
            gun = null;
        }
    }
}
