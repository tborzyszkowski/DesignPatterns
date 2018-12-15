using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.AbstractFactoryIsBetter;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    class BetterFactory
    {
        [Test]
        public void WarnLog()
        {
            LogFactory factory = WarningLogFactory.GetFactory();
            Log log = factory.CreateLog("UWAGA!");

            Assert.True(log.type == "WARN");
        }

        [Test]
        public void ErrorLog()
        {
            LogFactory factory = ErrorLogFactory.GetFactory();
            Log log = factory.CreateLog("Błąd!");

            Assert.True(log.type == "ERROR");
        }
    }
}
