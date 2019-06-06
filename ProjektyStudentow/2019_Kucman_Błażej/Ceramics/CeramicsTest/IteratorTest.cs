using Ceramics.Factories;
using Ceramics.Iterator;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Tests
{
    public class IteratorTest
    {
        public IMyData<int> array = null;
        [SetUp]
        public void SetUP()
        {
            array = new MyData<int>();
            array.AddItem(5);
            array.AddItem(6);
            array.AddItem(8);
        }

        [Test]
        public void TestNumberOfElements()
        {
            var numberOfElements = array.GetAll().Count;
            Assert.AreEqual(3, numberOfElements);
        }

        [Test]
        public void TestNumberOfElements2()
        {
            array.AddItem(3);
            var numberOfElements = array.GetAll().Count;
            Assert.AreEqual(4, numberOfElements);
        }
        [Test]
        public void TestFindElement()
        {
            var a = array.Find(6);
            Assert.AreEqual(a,6);
        }
        [Test]
        public void TestFindElementFault()
        {
            var a = array.Find(10);
            Assert.AreNotEqual(a, 10);
        }
        [Test]
        public void TestRemove()
        {
            array.Remove(6);
            var a = array.Find(6);
            Assert.AreNotEqual(a, 5);
        }
    }
}