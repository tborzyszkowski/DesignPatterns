using Printer.API.Models;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Printer.Printers
{
    internal abstract class FiscalPrinter : IFiscalPrinter
    {
        protected PrinterConfiguration _printerConfiguration;

        public FiscalPrinter(PrinterConfiguration configuration)
        {
            _printerConfiguration = configuration;
        }

        public virtual void CancelReceipt()
        {
            Console.WriteLine(PrintDebugLog());
        }

        public virtual bool Connect()
        {
            Console.WriteLine(PrintDebugLog());
            return true;
        }

        public virtual void EndReceipt()
        {
            Console.WriteLine(PrintDebugLog());
        }

        public virtual bool SellArticle(Article article)
        {
            Console.WriteLine(PrintDebugLog());
            return true;
        }

        public virtual void StartReceipt(int systemNumber)
        {
            Console.WriteLine(PrintDebugLog());
        }

        private string PrintDebugLog([CallerMemberName] string methodName = "")
        {
            return $"{this.GetType().Name} - {MethodBase.GetCurrentMethod().Name}";
        }
    }
}
