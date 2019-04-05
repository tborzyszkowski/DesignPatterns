using System;
using BuilderPattern.FluentBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuilderUnitTest
{
    [TestClass]
    public class FluentBuilderUnitTest
    {
        [TestMethod]
        public void checkValueFromCreatedSuperComputer()
        {
            ComputerStore computerStore = new ComputerStore();
            Computer computer = computerStore.Construct(new SuperComputerBuilder());

            Assert.AreEqual("1000GB", computer["hdd"]);

        }
        [TestMethod]
        public void checkTypeOfInstace()
        {
            ComputerStore computerStore = new ComputerStore();
            Computer computer = computerStore.Construct(new SuperComputerBuilder());

            Assert.IsInstanceOfType(computer, typeof(Computer));

        }

    }
}
