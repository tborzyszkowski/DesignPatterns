using Factory;
using Factory.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryTests
{
    [TestClass]
    public class AbstractFactoryTests
    {
        [TestMethod]
        public void CreateBookReader()
        {
            var factory = new BookReaderFactory();
            var obj = factory.Create();
            Assert.AreEqual("4", obj.Model);
            Assert.AreEqual("Amazon Kindle", obj.Manufacturer);
            Assert.AreEqual(64, obj.Memory);
            Assert.AreEqual(typeof(BookReader), obj.GetType());
        }
        [TestMethod]
        public void CreateSmartphone()
        {
            var factory = new SmartphoneFactory();
            var obj = factory.Create();
            Assert.AreEqual("S8", obj.Model);
            Assert.AreEqual("Samsung", obj.Manufacturer);
            Assert.AreEqual(32, obj.Memory);
            Assert.AreEqual(typeof(Smartphone), obj.GetType());
        }
        [TestMethod]
        public void CreateTablet()
        {
            var factory = new TabletFactory();
            var obj = factory.Create();
            Assert.AreEqual(typeof(Tablet), obj.GetType());
        }
        [TestMethod]
         public void CreateThreeSmartphones()
         {
            var factory = new SmartphoneFactory();
            var factory2 = new SmartphoneFactory2();
            var obj = factory.Create();
            var obj2 = factory2.Create();
            var obj3 = factory2.Create();

            Assert.AreNotSame(obj, obj2);
            Assert.AreNotSame(obj2, obj3);
            Assert.AreNotEqual(null, obj);
            Assert.AreNotEqual(null, obj2);
            Assert.AreNotEqual(null, obj3);
        }
    }
}
