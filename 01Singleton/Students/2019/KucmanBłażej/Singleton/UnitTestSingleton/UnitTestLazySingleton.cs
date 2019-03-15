using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singleton;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSingleton
{
    [TestClass]
    public class LazySingletonUnitTest
    {

        [TestMethod]
        public void TestIsValueCreated()
        {
            var a = new DerivedSingletonA();
            // a = DerivedSingleton.Instance;
            Assert.IsFalse(a.IsValueCreated);

        }

        [TestMethod]
        public void TestIsValueCreated2()
        {
            var a = new DerivedSingletonA();
            a = DerivedSingletonA.Instance;
            Assert.IsTrue(a.IsValueCreated);

        }

        [TestMethod]
        public void SimpleTestTwoCalls()
        {
            var a = DerivedSingletonA.Instance;
            var b = DerivedSingletonA.Instance;

            Assert.AreSame(a, b);

        }

    }
    [TestClass]
    public class UnitTestLazySingletonParaller
    {

        [TestMethod]
        public void checkIfInstanceWasCreated()
        {
            DerivedSingletonA a = null;
            DerivedSingletonA b = null;
            Parallel.Invoke(
               () => { a = DerivedSingletonA.Instance; }
               //() => { b = DerivedSingleton.Instance; }
            );

            Assert.AreNotSame(b, a);
        }

        [TestMethod]
        public void checkIfInstanceAreSame()
        {
            DerivedSingletonA a = null;
            DerivedSingletonA b = null;
            Parallel.Invoke(
               () => { a = DerivedSingletonA.Instance; },
               () => { b = DerivedSingletonA.Instance; }
            );

            Assert.AreSame(b, a);
        }

        [TestMethod]
        public void checkCounterAfterManyParallerCalls()
        {
            DerivedSingletonA a = null;

            Parallel.For(0, 10000000, task =>
            {
               a = DerivedSingletonA.Instance;
            });
            
            Assert.AreEqual(1,DerivedSingletonA.counter);
        }

        [TestMethod]
        public void TwoDiferentDervied()
        {
            DerivedSingletonA a = null;
            DerivedSingleton2 b = null;
            Parallel.Invoke(
               () => { a = DerivedSingletonA.Instance; },
               () => { b = DerivedSingleton2.Instance; }
            );

            Assert.AreNotSame(a, b);
        }

        [TestMethod]
        public void DoubleInherienceInstanceAreSame()
        {
            DerivedSingletonA a = null;
            DerivedSingletonA b = null;
            Parallel.Invoke(
               () => { a = DerivedSingletonA.Instance; },
               () => { b = DerivedSingletonB.Instance; }
            );

            Assert.AreSame(a, b);
        }
    }
}