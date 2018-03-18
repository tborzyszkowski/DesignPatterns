using System;
using Factory;
using Factory.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryTests
{
    [TestClass]
    public class ReflectionFactoryTests
    {
        [TestMethod]
        public void CreateByClassNameBookReader()
        {
            var obj = ReflectionDeviceFactory.CreateDevice("BookReader");
            Assert.AreEqual("4", obj.Model);
            Assert.AreEqual("Amazon Kindle", obj.Manufacturer);
            Assert.AreEqual(64, obj.Memory);
            Assert.AreEqual(typeof(BookReader), obj.GetType());
        }
        [TestMethod]
        public void CreateByClassTypeSmartphone()
        {
            var obj = ReflectionDeviceFactory.CreateDevice<Smartphone>();
            Assert.AreEqual("S8", obj.Model);
            Assert.AreEqual("Samsung", obj.Manufacturer);
            Assert.AreEqual(32, obj.Memory);
            Assert.AreEqual(typeof(Smartphone), obj.GetType());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateWrongTypeName()
        {
            var obj = ReflectionDeviceFactory.CreateDevice("BookReader2");
            Assert.AreEqual(null, obj);
            Assert.AreNotEqual(typeof(Tablet), obj.GetType());
        }
    }
}
