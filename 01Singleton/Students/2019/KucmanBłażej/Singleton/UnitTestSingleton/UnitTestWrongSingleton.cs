using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singleton;
using System.Threading.Tasks;

namespace UnitTestSingleton
{
    [TestClass]
    public class UnitTestWrongSingleton
    {

        [TestMethod]
        public void RunTwoThreadsShouldMakeInstanceTwoTimes()
        {
            WrongSingleton b = null;
            WrongSingleton c = null;
            Parallel.Invoke(
                    () => { b = WrongSingleton.GetOn(); },
                    () => { c = WrongSingleton.GetOn(); }
                );
            Assert.AreNotSame(c, b);
            Assert.AreNotEqual(1, WrongSingleton.counter);
        }

        [TestMethod]
        public void getTwoInstanceWithoutParallerFirstCreateInstanceForOther()
        {

            WrongSingleton a = WrongSingleton.GetOn();
            WrongSingleton b = WrongSingleton.GetOn();

            Assert.IsTrue(object.ReferenceEquals(a, b));
        }


        [TestMethod]
        public void GetInstancesWithParallerCounterMoreThanOne()
        {

            Parallel.For(0, 100000, task =>
            {
                WrongSingleton.GetOn();
            });
            Assert.AreNotEqual(1, WrongSingleton.counter);
        }

    }
}
