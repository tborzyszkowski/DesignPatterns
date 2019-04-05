using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrototypePattern.exercise2;

namespace PrototypeUnitTestProject
{
    [TestClass]
    public class exercise2Test
    {
        Computer computer;
        Computer computer1;

        [TestInitialize]
        public void Initialize()
        {
            computer = new Computer("Super", new Motherboard("asrock", new Chipset("ie3424", new Producent("Intel"))), "500GB", "s2500PLN");

            computer1 = null;

        }
        [TestMethod]
        public void useWrongCloneFunction()
        {
            computer1 = computer.CloneMemberwise() as Computer;
            computer1.Motherboard.chipset.name = "AMD";

            Assert.AreEqual(computer.Motherboard.chipset.name, computer1.Motherboard.chipset.name);
        }
        [TestMethod]
        public void useDeuplicateSerializeDepth1()
        {
            computer1 = computer.Duplicate() as Computer;
            computer1.Name = "AMD";

            Assert.AreNotEqual(computer.Name, computer1.Name);
        }
        [TestMethod]
        public void useDeuplicateSerializeDepth2()
        {
            computer1 = computer.Duplicate() as Computer;
            computer1.Motherboard.name = "XXXXXXX";

            Assert.AreNotEqual(computer.Motherboard.name, computer1.Motherboard.name);
        }
        [TestMethod]
        public void useDeuplicateSerializeDepth3()
        {
            computer1 = computer.Duplicate() as Computer;
            computer1.Motherboard.chipset.name = "AMD";

            Assert.AreNotEqual(computer.Motherboard.chipset.name, computer1.Motherboard.chipset.name);
        }
        [TestMethod]
        public void useDeuplicateSerializeDepth4()
        {
            computer1 = computer.Duplicate() as Computer;
            computer1.Motherboard.chipset.producent.name = "Innyy";

            Assert.AreNotEqual(computer.Motherboard.chipset.producent.name, computer1.Motherboard.chipset.producent.name);
        }

        [TestMethod]
        public void useDeuplicateSerializeNotChangedField()
        {
            computer1 = computer.Duplicate() as Computer;
            computer1.Motherboard.chipset.producent.name = "Innyy";

            Assert.AreEqual(computer.Motherboard.name, computer1.Motherboard.name);
        }
    }
}
