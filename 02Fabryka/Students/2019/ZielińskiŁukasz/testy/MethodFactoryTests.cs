using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Factory;
using Factory.Method;
using Factory.Frigates;
using Factory.CapitalShips;
using Factory.Cruisers;

namespace FactoryTests
{
    [TestClass]
    public class MethodFactoryTests
    {
        [TestMethod]
        public void CreateShip()
        {
            MethodFactory factory = EarthFactory.Instance;
            var ship = factory.BuildFrigate("disciple");
            Assert.IsNotNull(ship);
        }

        [TestMethod]
        public void CreateShip1()
        {
            MethodFactory factory = EarthFactory.Instance;
            var ship = factory.BuildCruiser("destra");
            Assert.IsNotNull(ship);
        }

        [TestMethod]
        public void CreateShip2()
        {
            MethodFactory factory = EarthFactory.Instance;
            var ship = factory.BuildCapitalShip("vulkoras");
            Assert.IsNotNull(ship);
        }

        [TestMethod]
        public void CreateShipWrong()
        {
            MethodFactory factory = EarthFactory.Instance;
            var ship = factory.BuildFrigate("aeria");
            Assert.IsNull(ship);
        }

        [TestMethod]
        public void CreateShipWrong1()
        {
            MethodFactory factory = EarthFactory.Instance;
            var ship = factory.BuildCruiser("dwqdqwd");
            Assert.IsNull(ship);
        }

        [TestMethod]
        public void CreateShipWrong2()
        {
            MethodFactory factory = EarthFactory.Instance;
            var ship = factory.BuildCapitalShip("asdadwdq");
            Assert.IsNull(ship);
        }

        [TestMethod]
        public void CreateShipEmpty()
        {
            MethodFactory factory = EarthFactory.Instance;
            var ship = factory.BuildFrigate(null);
            Assert.IsNull(ship);
        }

        [TestMethod]
        public void CreateShipEmpty1()
        {
            MethodFactory factory = EarthFactory.Instance;
            var ship = factory.BuildCruiser(null);
            Assert.IsNull(ship);
        }

        [TestMethod]
        public void CreateShipEmpty2()
        {
            MethodFactory factory = EarthFactory.Instance;
            var ship = factory.BuildCapitalShip(null);
            Assert.IsNull(ship);
        }

        [TestMethod]
        public void CreateWehicleChecEmptyName()
        {
            MethodFactory factory1 = MarsFactory.Instance;
            MethodFactory factory2 = MarsFactory.Instance;
            var ship1 = factory1.BuildCruiser("skarovas");
            var ship2 = factory2.BuildCruiser("skarovas");
            Assert.AreEqual(ship1.Name, ship2.Name);
        }

        
    }
}
