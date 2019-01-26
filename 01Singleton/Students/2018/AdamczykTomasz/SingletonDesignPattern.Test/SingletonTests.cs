using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SingletonDesignPattern.Test
{
    [TestClass]
    public class SingletonTests
    {
        [TestMethod]
        public void Test_ShouldBeTheSameInstances()
        {
            var instance1 = Singleton.Instance;
            var instance2 = Singleton.Instance;

            Assert.AreSame(instance1, instance2);
            Assert.AreEqual(instance1.GetCounter(), 1);

            instance1.DeleteInstance();
        }

        [TestMethod]
        public void Test_InheritedSingeton()
        {
            ParentSingleton<SonSingleton> sonInstance1 = SonSingleton.Instance;
            ParentSingleton<SonSingleton> sonInstance2 = SonSingleton.Instance;

            ParentSingleton<DaughterSingleton> daughterInstance1 = DaughterSingleton.Instance;
            ParentSingleton<DaughterSingleton> daughterInstance2 = DaughterSingleton.Instance;

            Assert.AreSame(sonInstance1, sonInstance2);
            Assert.AreSame(daughterInstance1, daughterInstance2);
            Assert.AreNotSame(sonInstance1, daughterInstance1);
        }
    }
}