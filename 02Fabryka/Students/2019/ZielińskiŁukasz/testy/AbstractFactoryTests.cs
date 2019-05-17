using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Factory;
using Factory.Abstract;

namespace FactoryTests
{
    [TestClass]
    public class AbstractFactoryTests
    {
        [TestMethod]
        public void CreateShipMoon()
        {
            AbstractFactory factory = new Abstract1(MoonAbstractFactory.Instance);
            var ship = factory.CreateFrigate();
            Assert.IsNotNull(ship);
        }

        [TestMethod]
        public void CreateShipMars()
        {
            AbstractFactory factory = new Abstract1(MarsAbstractFactory.Instance);
            var ship = factory.CreateFrigate();
            Assert.IsNotNull(ship);
        }

        [TestMethod]
        public void CreateShipEarth()
        {
            AbstractFactory factory = new Abstract1(EarthAbstractFactory.Instance);
            var ship = factory.CreateFrigate();
            Assert.IsNotNull(ship);
        }
    }
}
