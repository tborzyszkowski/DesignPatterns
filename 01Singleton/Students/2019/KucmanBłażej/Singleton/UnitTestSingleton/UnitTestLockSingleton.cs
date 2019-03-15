using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singleton;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSingleton
{
    [TestClass]
    public class UnitTestLockSingleton
    {
        [TestMethod]
        public void TestWithoutParaller()
        {
            var a = LockSingleton.getInstance();
            var b = LockSingleton.getInstance();

            Assert.IsTrue(object.ReferenceEquals(a, b));
        }
        [TestMethod]
        public void TestLockSingletonWithParaller()
        {
            LockSingleton a = null;
            LockSingleton b = null;
            LockSingleton c = null;
            Parallel.Invoke(
                () => { c = LockSingleton.getInstance(); },
                () => { b = LockSingleton.getInstance(); },
                () => { a = LockSingleton.getInstance(); },
                () => { c = LockSingleton.getInstance(); },
                () => { c = LockSingleton.getInstance(); }
            );

            Assert.IsTrue(object.ReferenceEquals(a, b));
            Assert.AreEqual(1, LockSingleton.counter);
        }

        [TestMethod]
        public void GetInstancesWithParaller()
        {

            Parallel.For(0, 100000, task =>
            {
                LockSingleton.getInstance();
            });
            Assert.AreEqual(1, LockSingleton.counter);
        }

    }
}
