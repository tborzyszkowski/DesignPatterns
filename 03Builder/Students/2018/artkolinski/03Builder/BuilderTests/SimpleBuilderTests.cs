using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleBuilder;
using SimpleBuilder.Models;
using SimpleBuilder.Products;

namespace BuilderTests
{
    [TestClass]
    public class SimpleBuilderTests
    {
        [TestMethod]
        public void SetName()
        {
            var flashlight = new Flashlight
            {
                ["Name"] = "testValue"
            };
            Assert.AreEqual("testValue", flashlight["Name"]);
        }
        
        [TestMethod]
        public void BuildSmallFlashlight()
        {
            var pm = new ProjectManager();
            var small = new SmallFlashlight();
            pm.Construct(small);
            var smallFlashlight = small.GetFlashlight();
            Assert.AreEqual("Small", smallFlashlight["Name"]);
            Assert.AreEqual("Small Host", smallFlashlight["Host"]);
            Assert.AreEqual("Small Driver", smallFlashlight["Driver"]);
            Assert.AreEqual("XM-L2", smallFlashlight["Led"]);
            Assert.AreEqual("Small Gift Box", smallFlashlight["Box"]);
        }

        [TestMethod]
        public void BuildBigFlashlight()
        {
            var pm = new ProjectManager();
            var big = new BigFlashlight();
            pm.Construct(big);
            var bigFlashlight = big.GetFlashlight();
            Assert.AreEqual("Big", bigFlashlight["Name"]);
            Assert.AreEqual("Big Host", bigFlashlight["Host"]);
            Assert.AreEqual("Big Driver", bigFlashlight["Driver"]);
            Assert.AreEqual("XHP-70", bigFlashlight["Led"]);
            Assert.AreEqual("Big Gift Box", bigFlashlight["Box"]);
        }
        [TestMethod]
        public void PratialBuildBigFlashlight()
        {
            var pm = new ProjectManager();
            var big = new BigFlashlight();
            pm.PartialConstruct(big);
            var bigFlashlight = big.GetFlashlight();
            Assert.AreEqual("Big", bigFlashlight["Name"]);
            Assert.AreEqual("XHP-70", bigFlashlight["Led"]);
            Assert.AreNotEqual("Big Host", bigFlashlight["Host"]);
            Assert.AreNotEqual("Big Driver", bigFlashlight["Driver"]);  
            Assert.AreNotEqual("Big Gift Box", bigFlashlight["Box"]);
        }
        [TestMethod]
        public void BuildBigFlashlightOnlyName()
        {
            var pm = new ProjectManager();
            var big = new BigFlashlight();
            pm.ConstructEmptyWithName(big);
            var bigFlashlight = big.GetFlashlight();
            Assert.AreEqual("Big", bigFlashlight["Name"]);
            Assert.AreEqual(null,bigFlashlight["Led"]);
            Assert.AreEqual(null, bigFlashlight["Host"]);
            Assert.AreEqual(null, bigFlashlight["Driver"]);
            Assert.AreEqual(null, bigFlashlight["Box"]);
        }
    }
}
