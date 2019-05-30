using Printer.API;
using Printer.API.Models;
using Printer.Factory;
using Printer.Printers;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printer.API
{
    public class PrinterFacade : IObservable<PrinterInfo>, IDisposable
    {
        private IFiscalPrinter _fiscalPrinter;
        private HashSet<IObserver<PrinterInfo>> _observers;

        public PrinterFacade(PrinterConfiguration configuration, PrinterType type)
        {
            var creator = Creator.Instance;
            _fiscalPrinter = creator.GetPrinter(type, configuration);
            _observers = new HashSet<IObserver<PrinterInfo>>();
        }

        internal PrinterFacade(
            IFiscalPrinter printer,
            PrinterConfiguration configuration,
            PrinterType type) : this(configuration, type)
        {
            _fiscalPrinter = printer;
        }

        public bool PrintReceipt(Receipt receipt)
        {
            try
            {
                _fiscalPrinter.Connect();
                _fiscalPrinter.StartReceipt(receipt.SystemNumber);
                foreach (var article in receipt.Articles)
                {
                    _fiscalPrinter.SellArticle(article);
                }

                _fiscalPrinter.EndReceipt();
                NotifyObservers(new PrinterInfo
                {
                    operationType = OperationType.Printed,
                    Description = $"Receipt {receipt.SystemNumber} printed"
                });
                return true;
            }
            catch
            {
                _fiscalPrinter.CancelReceipt();
                return false;
            }
        }

        public IDisposable Subscribe(IObserver<PrinterInfo> observer)
        {
            _observers.Add(observer);
            return new Unsubscriber(_observers, observer);
        }

        public void Dispose()
        {
            foreach (var observer in _observers)
            {
                observer.OnCompleted();
            }
            _observers.Clear();
        }

        private void NotifyObservers(PrinterInfo printerInfo)
        {
            foreach(var observer in _observers)
            {
                observer.OnNext(printerInfo);
            }
        }
    }

    public enum PrinterType
    {
        Posnet,
        Elzab,
        Novitus
    }
}
