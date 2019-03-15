using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp2;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void dwojeDzieci()
        {
            var log1 = ConsoleApp2.logerMlody1.dajLogera;
            var log2 = ConsoleApp2.logerMlody2.dajLogera;

            Assert.AreSame(log1, log2);
        }

        [TestMethod]
        public void synZOjcem()
        {
            var log1 = ConsoleApp2.logerMlody1.dajLogera;
            var log2 = ConsoleApp2.logerStary1.dajLogera;

            Assert.AreSame(log1, log2);
        }

        [TestMethod]
        public void synZWujem()
        {
            var log1 = ConsoleApp2.logerMlody1.dajLogera;
            var log2 = ConsoleApp2.logerStary2.dajLogera;

            Assert.AreNotSame(log1, log2);
        }

        [TestMethod]
        public void starzyBracia()
        {
            var log1 = ConsoleApp2.logerStary1.dajLogera;
            var log2 = ConsoleApp2.logerStary2.dajLogera;

            Assert.AreNotSame(log1, log2);
        }
    }
}
