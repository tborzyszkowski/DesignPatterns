using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prototype;

namespace PrototypeTests
{
    [TestClass]
    public class KingTests
    {
        King Arthur;
        King Mordred;

        [TestInitialize]
        public void Initialize()
        {
            Arthur = new King("Crown", new Armor("Three Crowns",
                     new Kingdom("242 495 km2", new Capital("Camelot", "2 559"))), "Chainmail", "Leather");
            Mordred = null;
        }
        
        [TestMethod]
        public void FakeCloneKingTest1()
        {
            Mordred = Arthur.CloneMemberwise() as King;
            Mordred.Cuirass.Crest = "Swords";
            Assert.AreEqual(Arthur.Cuirass.Crest, Mordred.Cuirass.Crest);
        }

        [TestMethod]
        public void CloneKingTest()
        {
            Mordred = Arthur.Usurper() as King;
            Mordred.Helmet = "none";
            Assert.AreNotEqual(Arthur.Helmet, Mordred.Helmet);
        }

        [TestMethod]
        public void CloneKingTest1()
        {
            Mordred = Arthur.Usurper() as King;
            Mordred.Cuirass.Crest = "Swords";
            Assert.AreEqual(Arthur.Helmet, Mordred.Helmet);
        }

        [TestMethod]
        public void CloneKingTest2()
        {
            Mordred = Arthur.Usurper() as King;
            Mordred.Cuirass.Nation.Size = "none";
            Assert.AreNotEqual(Arthur.Cuirass.Nation.Size, Mordred.Cuirass.Nation.Size);
        }

        [TestMethod]
        public void CloneKingTest3()
        {
            Mordred = Arthur.Usurper() as King;
            Mordred.Cuirass.Nation.Town.Name = "none";
            Assert.AreNotEqual(Arthur.Cuirass.Nation.Town.Name, Mordred.Cuirass.Nation.Town.Name);
        }
    }
}
