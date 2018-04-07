using FluentBuilder;
using FluentBuilder.Models;
using FluentBuilder.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuilderTests
{
    [TestClass]
    public class FluentBuilderTests
    {
        [TestMethod]
        public void PartListAccessors()
        {
            var flashlight = new Flashlight("Test");
            flashlight["test"] = "testValue";
            Assert.AreEqual("testValue", flashlight["test"]);
        }

        [TestMethod]
        public void PartListEditExistingValue()
        {
            var flashlight = new Flashlight("Test");
            flashlight["test"] = "testValue";
            flashlight["test"] = "editedTestValue";
            Assert.AreEqual("editedTestValue", flashlight["test"]);
        }

        [TestMethod]
        public void GetFlashlightType()
        {
            var flashlight = new Flashlight("Test");
            Assert.AreEqual("Test", flashlight.GetFlashlightType());
        }

        [TestMethod]
        public void GetValueByKeyCustomMethod()
        {
            var pm = new ProjectManager();
            var small = pm.Construct(new SmallFlashlight());
            Assert.AreEqual("Small Host", small.GetValueByKey("Host"));
        }
        [TestMethod]
        public void GetWrongValueByKeyCustomMethod()
        {
            var pm = new ProjectManager();
            var small = pm.Construct(new SmallFlashlight());
            Assert.AreEqual("Not exist", small.GetValueByKey("WrongHost"));
        }

        [TestMethod]
        public void GetFlashligthtParts()
        {
            var flashlight = new Flashlight("Test");
            flashlight["test"] = "testValue";
            flashlight["test2"] = "testValue2";
            flashlight["test3"] = "testValue3";
            Assert.AreEqual("testValue", flashlight["test"]);
            Assert.AreEqual("testValue2", flashlight["test2"]);
            Assert.AreEqual("testValue3", flashlight["test3"]);
        }

        [TestMethod]
        public void BuildSmallFlashlight()
        {
            var pm = new ProjectManager();
            var small = pm.Construct(new SmallFlashlight());

            Assert.AreEqual("Small", small.GetFlashlightType());
            Assert.AreEqual("Small Host", small["Host"]);
            Assert.AreEqual("Small Driver", small["Driver"]);
            Assert.AreEqual("XM-L2", small["Led"]);
            Assert.AreEqual("Small Gift Box", small["Box"]);
        }
        [TestMethod]
        public void BuildBigFlashlight()
        {
            var pm = new ProjectManager();
            var big = pm.Construct(new BigFlashlight());

            Assert.AreEqual("Big", big.GetFlashlightType());
            Assert.AreEqual("Big Host", big["Host"]);
            Assert.AreEqual("Big Driver", big["Driver"]);
            Assert.AreEqual("XHP-70", big["Led"]);
            Assert.AreEqual("Big Gift Box", big["Box"]);
        }
    }
}
