using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Printer.API;
using Printer.API.Models;
using Printer.Printers;

namespace Printer.Factory
{
    internal sealed class Creator
    {
        private static Creator _instance;
        private static object _instanceLock = new object();

        public static Creator Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                lock (_instanceLock)
                {
                    if (_instance != null)
                        return _instance;

                    _instance = new Creator();
                    return _instance;
                }
            }
        }

        private Creator() { }

        public IFiscalPrinter GetPrinter<T>(PrinterConfiguration configuration) where T : IFiscalPrinter
        {
            return (T)Activator.CreateInstance(typeof(T), configuration);
        }

        public IFiscalPrinter GetPrinter(PrinterType type, PrinterConfiguration configuration)
        {
            switch (type)
            {
                case PrinterType.Posnet:
                    return GetPrinter<PosnetPrinter>(configuration);
                case PrinterType.Elzab:
                    return GetPrinter<ElzabPrinter>(configuration);
                case PrinterType.Novitus:
                    return GetPrinter<NovitusPrinter>(configuration);
                default:
                    return GetPrinter<PosnetPrinter>(configuration);
            }
        }
    }
}
