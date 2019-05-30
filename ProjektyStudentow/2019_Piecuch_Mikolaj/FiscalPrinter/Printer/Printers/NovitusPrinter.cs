using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Printer.API.Models;

namespace Printer.Printers
{
    internal class NovitusPrinter : FiscalPrinter, IFiscalPrinter
    {
        public NovitusPrinter(PrinterConfiguration configuration) : base(configuration)
        {
        }

        public override void CancelReceipt()
        {
            base.CancelReceipt();
        }

        public override bool Connect()
        {
            return base.Connect();
        }

        public override void EndReceipt()
        {
            base.EndReceipt();
        }

        public override bool SellArticle(Article article)
        {
            return base.SellArticle(article);
        }

        public override void StartReceipt(int systemNumber)
        {
            base.StartReceipt(systemNumber);
        }
    }
}
