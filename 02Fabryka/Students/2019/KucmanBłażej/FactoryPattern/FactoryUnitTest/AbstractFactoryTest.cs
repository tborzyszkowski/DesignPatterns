using System;
using FactoryPattern.AbstractFactory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryUnitTest
{
    [TestClass]
    public class AbstractFactoryTest
    {
        [TestMethod]
        public void CreateWehicleCheckIsNotNull()
        {

            AbstarctFactory abstractFactory = new FactoryFA(PolandFactoryAF.Instance);
            var car = abstractFactory.CreateCar();
            Assert.IsNotNull(car);

        }
        [TestMethod]
        public void CreateWehicleComapreFromTwoFactory()
        {
            AbstarctFactory abstractFactoryP = new FactoryFA(PolandFactoryAF.Instance);
            AbstarctFactory abstractFactoryC = new FactoryFA(ChinaFactoryAF.Instance);
            var carP = abstractFactoryP.CreateCar();
            var carC = abstractFactoryC.CreateCar();
            Assert.AreNotEqual(carP.Name, carC.Name);

        }
    }
}
