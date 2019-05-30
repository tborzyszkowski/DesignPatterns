using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Sequences;
using Printer;
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
    public class FacadeTests
    {
        private Mock<IFiscalPrinter> _fiscalPrinterMock;
        private Receipt _receipt = new Receipt
        {
            Header = "Testowa firma",
            SystemNumber = 20,
            Articles = new List<Article>
                {
                    new Article
                    {
                        Name = "Test produkt",
                        Quantity = 2,
                        UnitOfMeasure = "szt.",
                        VAT = "A"
                    },
                    new Article
                    {
                        Name = "Test produkt1",
                        Quantity = 2,
                        UnitOfMeasure = "szt.",
                        VAT = "A"
                    }
                }
        };

        public FacadeTests()
        {
            _fiscalPrinterMock = new Mock<IFiscalPrinter>(MockBehavior.Strict);
        }

        [TestMethod]
        public void PrintReceiptShouldCoverAllSteps()
        {
            using (Sequence.Create())
            {
                _fiscalPrinterMock
                    .Setup(x => x.Connect())
                    .InSequence()
                    .Returns(true);
                _fiscalPrinterMock
                    .Setup(x => x.StartReceipt(It.IsAny<int>()))
                    .InSequence();
                _fiscalPrinterMock
                    .Setup(x => x.SellArticle(It.IsAny<Article>()))
                    .InSequence(Times.Exactly(_receipt.Articles.Count))
                    .Returns(true);
                _fiscalPrinterMock
                    .Setup(x => x.EndReceipt())
                    .InSequence();

                var facade = new PrinterFacade(_fiscalPrinterMock.Object, new PrinterConfiguration(), PrinterType.Elzab);
                facade.PrintReceipt(_receipt);
            }

            _fiscalPrinterMock.VerifyAll();
        }

        
    }
}
