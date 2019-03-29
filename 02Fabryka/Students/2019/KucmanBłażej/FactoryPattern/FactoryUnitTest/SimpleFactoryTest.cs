using System;
using FactoryPattern.SimpleFactory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryUnitTest
{
    [TestClass]
    public class SimpleFactoryTest
    {
        [TestMethod]
        public void CreateWehicleCheckIsNotNull()
        {
            WehicleFactory factory = WehicleFactory.Instance;
            var car = factory.CreateCar("MediumCar");
            Assert.IsNotNull(car);

        }
        [TestMethod]
        public void CreateWehicleCheckWrongName()
        {
            WehicleFactory factory = WehicleFactory.Instance;
            var car = factory.CreateCar("MediumCaree");
            Assert.IsNull(car);

        }
        [TestMethod]
        public void CreateWehicleChecNameTruck()
        {
            WehicleFactory factory = WehicleFactory.Instance;
            var truck = factory.CreateTruck("Mac");
            Assert.AreEqual(truck.Name, "Titan");

        }
        [TestMethod]
        public void CreateWehicleChecEmptyName()
        {
            WehicleFactory factory = WehicleFactory.Instance;
            var truck = factory.CreateTruck(null);
            Assert.IsNull(truck);

        }
    }
}
