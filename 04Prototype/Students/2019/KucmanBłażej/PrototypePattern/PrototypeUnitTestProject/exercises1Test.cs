using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrototypePattern.exercise1;

namespace PrototypeUnitTestProject
{
    [TestClass]
    public class exercises1Test
    {
        Computer computer;
        Computer computer1;

        [TestInitialize]
        public void Initialize()
        {
            computer = new Computer("KOKO", "Asrok", "Intel", "500");
            computer1 = null;
            
        }
        [TestMethod]
        public void wrongCopyTest()
        {
            
            computer1 = computer;
            computer1.Motherboard = "Inna";

            Assert.AreEqual(computer.Motherboard, computer1.Motherboard);

        }
        [TestMethod]
        public void useCloneFunctionToCopy()
        {
            computer1 = computer.Clone() as Computer;
            computer1.Motherboard = "Inna";

            Assert.AreNotEqual(computer.Motherboard, computer1.Motherboard);
        }
    }
}
