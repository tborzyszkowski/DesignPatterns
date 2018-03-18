using System;
using Factory;
using Factory.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryTests
{
    [TestClass]
    public class SimpleFactoryTests
    {
        [TestMethod]
        public void CreateBookReader()
        {
            var factory = new SimpleDeviceFactory();
            var obj = factory.CreateDevice("BookReader");
            Assert.AreEqual("4", obj.Model);
            Assert.AreEqual("Amazon Kindle", obj.Manufacturer);
            Assert.AreEqual(64, obj.Memory);
            Assert.AreEqual(typeof(BookReader), obj.GetType());
        }
        [TestMethod]
        public void CreateSmartphone()
        {
            var factory = new SimpleDeviceFactory();
            var obj = factory.CreateDevice("Smartphone");
            Assert.AreEqual(typeof(Smartphone), obj.GetType());
        }
        [TestMethod]
        public void CreateTablet()
        {
            var factory = new SimpleDeviceFactory();
            var obj = factory.CreateDevice("Tablet");
            Assert.AreEqual(typeof(Tablet), obj.GetType());
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CreateWrongTypeName()
        {
            var factory = new SimpleDeviceFactory();
            var obj = factory.CreateDevice("tablet");
            Assert.AreEqual(null, obj);
            Assert.AreNotEqual(typeof(Tablet), obj.GetType());
        }
    }
}
