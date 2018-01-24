using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChronoSortCore.Parameters;

namespace ChronoSortCoreUnitTests
{
    [TestClass]
    public class ParameterFactoryTests
    {
        [TestMethod]
        public void ParameterFactoryShortOptionPositiveTest()
        {
            var command = @"-s C:\some\path\to\file";

            var parameter = ParameterFactory.GetParameter(command);

            Assert.IsTrue(parameter.GetType() == typeof(Source));
        }

        [TestMethod]
        public void ParameterFactoryShortOptionNegativeTest()
        {
            var command = @"-ss C:\some\path\to\file";

            var parameter = ParameterFactory.GetParameter(command);

            Assert.IsNull(parameter);
        }

        [TestMethod]
        public void ParameterFactoryLongOptionPositiveTest()
        {
            var command = @"-source C:\some\path\to\file";

            var parameter = ParameterFactory.GetParameter(command);

            Assert.IsTrue(parameter.GetType() == typeof(Source));
        }

        [TestMethod]
        public void ParameterFactoryLongOptionNegativeTest()
        {
            var command = @"-sources C:\some\path\to\file";

            var parameter = ParameterFactory.GetParameter(command);

            Assert.IsNull(parameter);
        }

        [TestMethod]
        public void ParameterFactoryHelpTest()
        {
            var command = @"-h";

            var parameter = ParameterFactory.GetParameter(command);

            Assert.IsTrue(parameter.GetType() == typeof(Help) && parameter.Validate());

            command = @"-help";

            parameter = ParameterFactory.GetParameter(command);

            Assert.IsTrue(parameter.GetType() == typeof(Help) && parameter.Validate());

            command = @"-help something\here";

            parameter = ParameterFactory.GetParameter(command);

            Assert.IsFalse(parameter.Validate());
        }
    }
}
