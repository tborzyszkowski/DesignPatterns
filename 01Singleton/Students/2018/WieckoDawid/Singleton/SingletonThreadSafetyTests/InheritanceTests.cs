using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singleton;

namespace SingletonThreadSafetyTests
{
    [TestClass]
    public class InheritanceTests
    {
        [TestMethod]
        [TestCategory("Inheritance - same")]
        public void Test_Inheritance_Of_Childrens()
        { 
            SingletonA<SingletonB> firstSon = SingletonB.Instance;
            SingletonA<SingletonB> secondSon = SingletonB.Instance;

            SingletonA<SingletonC> firstDaughter = SingletonC.Instance;
            SingletonA<SingletonC> secondDaughter = SingletonC.Instance;

            Assert.AreSame(firstSon, secondSon);
            Assert.AreSame(firstDaughter, secondDaughter);
        }
        [TestMethod]
        [TestCategory("Inheritance - not same")]
        public void Test_Inheritance_OfChildrens_ChildrensAre_Not_TheSame()
        {
            SingletonA<SingletonB> firstSon = SingletonB.Instance;
            SingletonA<SingletonB> secondSon = SingletonB.Instance;

            SingletonA<SingletonC> firstDaughter = SingletonC.Instance;
            SingletonA<SingletonC> secondDaughter = SingletonC.Instance;

            Assert.AreNotSame(firstSon, firstDaughter);
        }
    }
}
