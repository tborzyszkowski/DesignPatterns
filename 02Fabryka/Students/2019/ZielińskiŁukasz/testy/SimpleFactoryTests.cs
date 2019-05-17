using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Factory;

namespace FactoryTests
{
    [TestClass]
    public class SimpleFactoryTests
    {
        [TestMethod]
        public void CreateShip()
        {
            SimpleFactory factory = SimpleFactory.Instance;
            var ship = factory.CreateFrigate("cobalt");
            Assert.IsNotNull(ship);
        }

        [TestMethod]
        public void CreateShip1()
        {
            SimpleFactory factory = SimpleFactory.Instance;
            var ship = factory.CreateCruiser("kodiak");
            Assert.IsNotNull(ship);
        }

        [TestMethod]
        public void CreateShip2()
        {
            SimpleFactory factory = SimpleFactory.Instance;
            var ship = factory.CreateCapitalShip("sova");
            Assert.IsNotNull(ship);
        }

        [TestMethod]
        public void CreateShipWrong()
        {
            SimpleFactory factory = SimpleFactory.Instance;
            var ship = factory.CreateFrigate("asdf");
            Assert.IsNull(ship);
        }

        [TestMethod]
        public void CreateShipWrong1()
        {
            SimpleFactory factory = SimpleFactory.Instance;
            var ship = factory.CreateCruiser("cobalt");
            Assert.IsNull(ship);
        }

        [TestMethod]
        public void CreateShipWrong2()
        {
            SimpleFactory factory = SimpleFactory.Instance;
            var ship = factory.CreateCapitalShip("cobalt");
            Assert.IsNull(ship);
        }

        [TestMethod]
        public void CreateShipEmpty()
        {
            SimpleFactory factory = SimpleFactory.Instance;
            var ship = factory.CreateFrigate(null);
            Assert.IsNull(ship);
        }

        [TestMethod]
        public void CreateShipEmpty1()
        {
            SimpleFactory factory = SimpleFactory.Instance;
            var ship = factory.CreateCruiser(null);
            Assert.IsNull(ship);
        }

        [TestMethod]
        public void CreateShipEmpty2()
        {
            SimpleFactory factory = SimpleFactory.Instance;
            var ship = factory.CreateCapitalShip(null);
            Assert.IsNull(ship);
        }
    }
}
