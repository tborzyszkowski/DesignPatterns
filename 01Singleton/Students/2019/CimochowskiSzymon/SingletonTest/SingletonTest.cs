using System;
using System.Reflection;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using Singleton;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SingletonTest
{
    [TestClass]
    public class SingletonTest
    {
        [TestMethod]
        public void AreSingletonInstancesSame()
        {
            LazySingleton firstInstance = LazySingleton.getInstance();
            LazySingleton secondInstance = LazySingleton.getInstance();

            Assert.AreSame(firstInstance, secondInstance);
        }

        [TestMethod]
        public void AreSingletonHashcodesSame()
        {
            LazySingleton firstInstance = LazySingleton.getInstance();
            LazySingleton secondInstance = LazySingleton.getInstance();
            
            Assert.AreEqual(firstInstance.GetHashCode(), secondInstance.GetHashCode());
        }

        [TestMethod]
        public void TwoInstancesAreTheSame_NormalMethod()
        {
            GenericSingleton<GenOneSingleton> firstOne = GenOneSingleton.getInstance;
            GenericSingleton<GenOneSingleton> secondOne = GenOneSingleton.getInstance;

            GenericSingleton<GenTwoSingleton> firstTwo = GenTwoSingleton.getInstance;
            GenericSingleton<GenTwoSingleton> secondTwo = GenTwoSingleton.getInstance;
            
            Assert.AreSame(firstOne,secondOne);
            Assert.AreSame(firstTwo, secondTwo);
            Assert.AreNotSame(firstOne, firstTwo);
        }

        [TestMethod]
        public void TwoInstancesAreTheSame_ParallelMethod()
        {
            GenericSingleton<GenOneSingleton> firstOne = null;
            GenericSingleton<GenOneSingleton> secondOne = null;

            Parallel.Invoke(
                () => firstOne = GenOneSingleton.getInstance,
                () => secondOne = GenOneSingleton.getInstance
                );

            Assert.AreSame(firstOne, secondOne);
        }

        [TestMethod]
        public void TwoInheritedInstancesAreTheSame()
        {
            GenericSingleton<GenOneSingleton> son = null;
            GenericSingleton<GenOneSingleton> sonOfTheSon = null;

            Parallel.Invoke(
                () => son = GenOneSingleton.getInstance,
                () => sonOfTheSon = GenThreeSingleton.getInstance);

            Assert.AreSame(son, sonOfTheSon);
        }

        [TestMethod]
        public void CheckCounter()
        {
            LazySingleton firstInstance = LazySingleton.getInstance();
            firstInstance = LazySingleton.getInstance();

            Assert.AreEqual(1, firstInstance.getCounter());
        }

        [TestMethod]
        public void CheckGenericCounter()
        {
            GenericSingleton<GenOneSingleton> firstOne = GenOneSingleton.getInstance;
            firstOne = GenOneSingleton.getInstance;

            Assert.AreEqual(1, firstOne.getCounter());
        }
    }
}
