using System;
using FactoryPattern.FactoryMethodC;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryUnitTest
{
    [TestClass]
    public class FactoryMethodTest
    {
        [TestMethod]
        public void CreateWehicleCheckIsNotNull()
        {
            WehicleFactoryFM fmp = PolandFactory.Instance;
            var car = fmp.MakeCar("MediumCar");
            Assert.IsNotNull(car);

        }
        [TestMethod]
        public void CreateWehicleCheckWrongName()
        {
            WehicleFactoryFM fmp = PolandFactory.Instance;
            var car = fmp.MakeCar("MediumCareee");
            Assert.IsNull(car);

        }
        [TestMethod]
        public void CreateWehicleChecNameTruck()
        {
            WehicleFactoryFM fmp = PolandFactory.Instance;
            WehicleFactoryFM fmc = ChinaFactory.Instance;
            var carP = fmp.MakeCar("MediumCar");
            var carC = fmc.MakeCar("MediumCar");
            Assert.AreNotEqual(carP.Price, carC.Price);

        }
        [TestMethod]
        public void CreateWehicleChecEmptyName()
        {
            WehicleFactoryFM fmp = PolandFactory.Instance;
            WehicleFactoryFM fmc = PolandFactory.Instance;
            var carP = fmp.MakeCar("MediumCar");
            var carC = fmc.MakeCar("MediumCar");
            Assert.AreEqual(carP.Price, carC.Price);

        }
    }
}
