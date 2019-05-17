using GunStore;
using GunStore.Builder;
using GunStore.Iterator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GunStoreTest
{
    [TestClass]
    public class GunStoreIteratorTests
    {
        private Store store;
        private int n;
        private int index;
        private IIterator<Gun> iterator;

        [TestInitialize]
        public void Initialize()
        {
            n = 3;
            store = new Store();
            store.Add(GunFactory.Instance.Construct(new AK47Builder()));
            store.Add(GunFactory.Instance.Construct(new AK47Builder()));
            store.Add(GunFactory.Instance.Construct(new M1911Builder()));
            store.Add(GunFactory.Instance.Construct(new M870Builder()));
            iterator = store.CreateIterator();
            index = 1;
        }

        [TestMethod]
        public void CurrentIndexReturnsObjectOnActualIndex()
        {
            iterator.At(index);
            Assert.AreEqual(index, iterator.CurrentIndex);
        }

        [TestMethod]
        public void FirstReturnsObjectOnFirstIndex()
        {
            iterator.First();
            Assert.AreEqual(0, iterator.CurrentIndex);
        }

        [TestMethod]
        public void LastReturnsObjectOnLastIndex()
        {
            iterator.Last();
            Assert.AreEqual(n - 1, iterator.CurrentIndex);
        }

        [TestMethod]
        public void NextReturnsObjectOnNextIndex()
        {
            iterator.At(index);
            iterator.Next();
            Assert.AreEqual(index + 1, iterator.CurrentIndex);
        }

        [TestMethod]
        public void PrevReturnsObjectOnPreviousIndex()
        {
            iterator.At(index);
            iterator.Prev();
            Assert.AreEqual(index - 1, iterator.CurrentIndex);
        }

        [TestCleanup]
        public void Cleanup()
        {
            n = 0;
            store = null;
        }
    }
}
