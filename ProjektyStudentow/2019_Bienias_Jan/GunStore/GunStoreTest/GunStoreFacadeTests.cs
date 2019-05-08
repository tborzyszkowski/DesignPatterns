using GunStore;
using GunStore.Builder;
using GunStore.Enums;
using GunStore.Facade;
using GunStore.Iterator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GunStoreTest
{
    [TestClass]
    public class GunStoreFacadeTests
    {
        private GunShop gunShop;
        private Store store;

        [TestInitialize]
        public void Initialize()
        {
            store = new Store();
            store.Add(GunFactory.Instance.Construct(new AK47Builder()));
            store.Add(GunFactory.Instance.Construct(new MP5Builder()));
            store.Add(GunFactory.Instance.Construct(new M1911Builder()));
            store.Add(GunFactory.Instance.Construct(new M870Builder()));
            gunShop = new GunShop(store);
        }

        [TestMethod]
        public void FindByStringReturnsGunListThatContainAskedStringInTheirName()
        {
            var list = gunShop.Find("m"); //M1911, MP5 and M870
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void FindByTypeReturnsListWithGunsOfAskedGunType()
        {
            var list = gunShop.Find(GunType.Rifle);
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void ShowAllReturnsGunList()
        {
            var list = gunShop.ShowAll();
            Assert.AreEqual(4, list.Count);
        }

        [TestMethod]
        public void AtReturnsStringInfoAboutGunOnGivenIndexAndSetsCurrentIndex()
        {
            string gunInfo = gunShop.At(1);
            Assert.IsTrue(gunInfo.ToLower().Contains("mp5"));
            Assert.AreEqual(1, gunShop.CurrentIndex);
        }

        [TestMethod]
        public void ShowNextReturnsStringInfoAboutGunOnNextIndex()
        {
            var index = 1;
            gunShop.At(index);
            string gunInfo = gunShop.ShowNext();
            Assert.AreEqual(index + 1, gunShop.CurrentIndex);
        }

        [TestMethod]
        public void ShowPrevReturnsStringInfoAboutGunOnPreviousIndex()
        {
            var index = 1;
            gunShop.At(index);
            string gunInfo = gunShop.ShowPrev();
            Assert.AreEqual(index - 1, gunShop.CurrentIndex);
        }

        [TestMethod]
        public void BuyReturnsCopyOfGunAndRemovesItFromTheList()
        {
            var list = gunShop.ShowAll();
            int count = list.Count;
            var gun = gunShop.Buy(1);
            list = gunShop.ShowAll();
            Assert.AreEqual(count - 1, list.Count);
        }

        [TestMethod]
        public void AttachHoloSightDecoratesGunWithHolographicSight()
        {
            AbstractGun gun = gunShop.Buy(1);
            gun = gunShop.AttachHoloSight(gun as Gun);
            Assert.IsTrue(gun.ToString().ToLower().Contains("holographic sight"));
        }

        [TestMethod]
        public void AttachLaserSightDecoratesGunWithLaserSight()
        {
            AbstractGun gun = gunShop.Buy(1);
            gun = gunShop.AttachLaserSight(gun as Gun);
            Assert.IsTrue(gun.ToString().ToLower().Contains("laser sight"));
        }

        [TestMethod]
        public void AttachSilencerDecoratesGunWithSilencer()
        {
            AbstractGun gun = gunShop.Buy(1);
            gun = gunShop.AttachSilencer(gun as Gun);
            Assert.IsTrue(gun.ToString().ToLower().Contains("silencer"));
        }

        [TestCleanup]
        public void Cleanup()
        {
            gunShop = null;
            store = null;
        }
    }
}
