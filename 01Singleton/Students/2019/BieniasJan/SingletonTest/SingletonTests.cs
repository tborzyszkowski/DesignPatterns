using System;
using Singleton;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

//Jan Bienias 238201
//Testy dla dwóch klas - Singleton i AnotherSingleto dziedziczacych po generycznej klasie GenericSingleton<T>, gdzie T = class
//(i AnotherAnotherSingleton, ktora dziedziczy po AnotherSingleton)

namespace Singleton.Test
{
    [TestClass]
    public class SingletonTests
    {
        [TestMethod]
        public void InstancePropertyReturnsSameInstance_SingleThread()
        {
            var a = Singleton.Instance;
            var b = Singleton.Instance;

            Assert.AreSame(a, b); //Assert.IsTrue(a == b); / ReferenceEquals
        }

        [TestMethod]
        public void OnlyOneInstanceExists_SingleThread()
        {
            var a = Singleton.Instance;
            var b = Singleton.Instance;

            Assert.AreEqual(1, Singleton.Counter);
        }

        [TestMethod]
        public void InstancePropertyReturnsSameInstance_MultiplePararellThreads()
        {
            AnotherSingleton a = null;
            AnotherSingleton b = null;
            Parallel.Invoke(
                () => { a = AnotherAnotherSingleton.Instance; },
                () => { b = AnotherSingleton.Instance; }
            );

            Assert.AreSame(b, AnotherAnotherSingleton.Instance);
        }

        [TestMethod]
        public void OnlyOneInstanceExists_MultiplePararellThreads()
        {
            AnotherSingleton a = null;
            AnotherSingleton b = null;
            Parallel.Invoke(
                () => { a = AnotherSingleton.Instance; },
                () => { b = AnotherSingleton.Instance; }
            );

            Assert.AreEqual(1, AnotherSingleton.Counter);
        }

        [TestMethod]
        public void InheritedClassesFromGenericSingletonAreNotSame()
        {
            var a = Singleton.Instance;
            var b = AnotherSingleton.Instance;
            Assert.AreNotSame(a, b);
        }
    }
}
