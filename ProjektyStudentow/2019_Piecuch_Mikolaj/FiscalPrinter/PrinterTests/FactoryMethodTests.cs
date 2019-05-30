using Microsoft.VisualStudio.TestTools.UnitTesting;
using Printer.API;
using Printer.API.Models;
using Printer.Factory;
using Printer.Printers;

namespace PrinterTests
{
    [TestClass]
    public class FactoryMethodTests
    {
        private PrinterConfiguration _configuration = new PrinterConfiguration
        {
            Port = "COM1",
            Parity = System.IO.Ports.Parity.Even,
            Speed = 9600,
            StopBits = System.IO.Ports.StopBits.None
        };

        [TestMethod]
        public void FactoryMethodGeneric()
        {
            var creator = Creator.Instance;

            var elzab = creator.GetPrinter<ElzabPrinter>(_configuration);
            Assert.IsInstanceOfType(elzab, typeof(ElzabPrinter));

            var novitus = creator.GetPrinter<NovitusPrinter>(_configuration);
            Assert.IsInstanceOfType(novitus, typeof(NovitusPrinter));

            var posnet = creator.GetPrinter<PosnetPrinter>(_configuration);
            Assert.IsInstanceOfType(posnet, typeof(PosnetPrinter));
        }

        [TestMethod]
        public void FactoryMethodBasedOnType()
        {
            var creator = Creator.Instance;
            var elzab = creator.GetPrinter(PrinterType.Elzab,_configuration);
            Assert.IsInstanceOfType(elzab, typeof(ElzabPrinter));

            var novitus = creator.GetPrinter(PrinterType.Novitus, _configuration);
            Assert.IsInstanceOfType(novitus, typeof(NovitusPrinter));

            var posnet = creator.GetPrinter(PrinterType.Posnet, _configuration);
            Assert.IsInstanceOfType(posnet, typeof(PosnetPrinter));
        }
    }
}
