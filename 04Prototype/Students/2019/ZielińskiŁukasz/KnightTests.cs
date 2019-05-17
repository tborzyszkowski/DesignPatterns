using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prototype;

namespace PrototypeTests
{
    [TestClass]
    public class KnightTests
    {
        Knight Gawain;
        Knight Lancelot;

        [TestInitialize]
        public void Initialize()
        {
            Gawain = new Knight("Full", "Plate", "Chainmail", "Leather");
            Lancelot = null;
        }

        [TestMethod]
        public void DopplerKnightTest() 
        {
            Lancelot = Gawain;
            Lancelot.Helmet = "none";
            Assert.AreEqual(Gawain.Helmet, Lancelot.Helmet);
        }

        [TestMethod]
        public void CloneKnightTest()
        {
            Lancelot = Gawain.Clone() as Knight;
            Lancelot.Cuirass = "Chainmail";
            Assert.AreNotEqual(Gawain.Cuirass, Lancelot.Cuirass);
        }
    }
}
