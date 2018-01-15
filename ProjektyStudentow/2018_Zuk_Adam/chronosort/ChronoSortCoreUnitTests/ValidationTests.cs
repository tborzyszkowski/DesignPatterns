using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChronoSortCore.Parameters;
using ChronoSortCore.Utils;

namespace ChronoSortCoreUnitTests
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void ValidateArgsEmptyStringTest()
        {
            var param = Validation.ValidateArgs("");

            Assert.IsNull(param);
        }

        [TestMethod]
        public void ValidateArgsSingleParamWithoutValueTest()
        {
            var param = Validation.ValidateArgs("-help");

            Assert.IsTrue(param.GetType() == typeof(Help));
        }

        [TestMethod]
        public void ValidateArgsSingleParamWithValueTest()
        {
            var param = Validation.ValidateArgs(@"-source C:\Path\To\File");

            Assert.IsTrue(param.GetType() == typeof(Source));
        }

        [TestMethod]
        public void ValidateIfFileExistsNegativeTest()
        {
            var result = Validation.ValidateIfFileExists(@"\Path\To\File");

            Assert.IsFalse(result);
        }
    }
}
