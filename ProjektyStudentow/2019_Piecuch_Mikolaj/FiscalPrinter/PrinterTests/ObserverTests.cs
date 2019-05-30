using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Printer.API;
using Printer.API.Models;
using Printer.Printers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterTests
{
    [TestClass]
    public class ObserverTests
    {
        [TestMethod]
        public void FacadeShouldNotifyOfPrintReceipt()
        {
            var observerMock = new Mock<IObserver<PrinterInfo>>(MockBehavior.Strict);
            observerMock
                .Setup(x => x.OnNext(It.IsAny<PrinterInfo>()))
                .Callback<PrinterInfo>(x =>
                {
                    Assert.AreEqual(x.operationType, OperationType.Printed);
                });

            var fiscalPrinterMock = new Mock<IFiscalPrinter>(MockBehavior.Strict);
            fiscalPrinterMock
                .Setup(x => x.Connect())
                .Returns(true);
            fiscalPrinterMock
                .Setup(x => x.StartReceipt(It.IsAny<int>()));
            fiscalPrinterMock
                .Setup(x => x.SellArticle(It.IsAny<Article>()))
                .Returns(true);
            fiscalPrinterMock
                .Setup(x => x.EndReceipt());

            var facade = new PrinterFacade(fiscalPrinterMock.Object, new PrinterConfiguration(), PrinterType.Posnet);
            facade.Subscribe(observerMock.Object);
            facade.PrintReceipt(new Receipt
            {
                Articles = new List<Article>()
            });

            observerMock.Verify(x => x.OnNext(It.IsAny<PrinterInfo>()), Times.Once());
        }
    }
}
