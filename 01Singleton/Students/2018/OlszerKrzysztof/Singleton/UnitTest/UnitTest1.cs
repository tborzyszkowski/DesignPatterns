using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var s1 = Singleton.Singleton.getInstance();
            var s2 = Singleton.Singleton.getInstance();
            s1.x = 5;
            s2.x = 10;

            Assert.AreEqual(s1, s2);
      
            Singleton.Singleton.setNullInstance();
        }

        [TestMethod]
        public void TestMethod2()
        {
            Parallel.For(0, 1000000,
                i =>
                {
                    Singleton.Singleton.getInstance();
                });
            Assert.AreEqual(1, Singleton.Singleton.count);

            Singleton.Singleton.setNullInstance();
        }

        [TestMethod]
        public void TestMethod3()
        {
            Parallel.For(0, 1000000,
                i =>
                {
                    Singleton.SingletonThreadSafe.getInstance();
                });
            Assert.AreEqual(1, Singleton.SingletonThreadSafe.count);

            Singleton.SingletonThreadSafe.setNullInstance();
        }
    }
}
