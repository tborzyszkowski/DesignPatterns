using GunStore;
using GunStore.Builder;
using GunStore.Iterator;
using GunStore.Visitor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GunStoreTest
{
    [TestClass]
    public class GunStoreVisitorTests
    {
        private Store store;
        private IIterator<Gun> iterator;

        [TestInitialize]
        public void Initialize()
        {
            store = new Store();
            store.Add(GunFactory.Instance.Construct(new AK47Builder()));
            store.Add(GunFactory.Instance.Construct(new MP5Builder()));
            store.Add(GunFactory.Instance.Construct(new M1911Builder()));
            store.Add(GunFactory.Instance.Construct(new M870Builder()));
            iterator = store.CreateIterator();
        }

        [TestMethod]
        public void BargainPriceVisitorDecreasesPriceBy20Percent()
        {
            var gun = iterator.Current;
            decimal prevPrice = gun.BasePrice;
            store.Accept(new BargainPriceVisitor());
            decimal newPrice = gun.BasePrice;
            Assert.AreEqual(prevPrice * 0.8m, newPrice);
        }

        [TestMethod]
        public void IncreasePriceVisitorIncreasesPriceBy25Percent()
        {
            var gun = iterator.Current;
            decimal prevPrice = gun.BasePrice;
            store.Accept(new IncreasePriceVisitor());
            decimal newPrice = gun.BasePrice;
            Assert.AreEqual(prevPrice * 1.25m, newPrice);
        }

        [TestMethod]
        public void UsingBargainPriceVisitorAndThenIncreasePriceVisitorSetsPricesToTheirBeginningState()
        {
            var gun = iterator.Current;
            decimal prevPrice = gun.BasePrice;
            store.Accept(new BargainPriceVisitor());
            store.Accept(new IncreasePriceVisitor());
            decimal newPrice = gun.BasePrice;
            Assert.AreEqual(prevPrice, newPrice);
        }

        [TestCleanup]
        public void Cleanup()
        {
            store = null;
            iterator = null;
        }
    }
}
