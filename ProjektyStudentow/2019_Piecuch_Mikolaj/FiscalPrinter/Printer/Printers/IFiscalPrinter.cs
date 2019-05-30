using Printer.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printer.Printers
{
    internal interface IFiscalPrinter
    {
        bool Connect();
        void StartReceipt(int systemNumber);
        bool SellArticle(Article article);
        void CancelReceipt();
        void EndReceipt();
    }
}
