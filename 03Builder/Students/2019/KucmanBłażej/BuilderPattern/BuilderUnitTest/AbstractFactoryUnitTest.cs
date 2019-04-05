using System;
using BuilderPattern.AbstractFactory;
using BuilderPattern.AbstractFactory.ComputerFactory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuilderUnitTest
{
    [TestClass]
    public class AbstractFactoryUnitTest
    {
        [TestMethod]
        public void CreateComputerCheckIsNotNull()
        {
            AbstractFactory abstractFactory = new FactoryFA(PolandFactory.Instance);
            var computer = abstractFactory.CreateComputer();
            Assert.IsNotNull(computer);
        }

        [TestMethod]
        public void CreateComputerCheckName()
        {
            AbstractFactory abstractFactoryP = new FactoryFA(PolandFactory.Instance);
            var computer = abstractFactoryP.CreateComputer();
            Assert.AreEqual("SuperComputer", computer.ComputerName);

        }
    }
}
