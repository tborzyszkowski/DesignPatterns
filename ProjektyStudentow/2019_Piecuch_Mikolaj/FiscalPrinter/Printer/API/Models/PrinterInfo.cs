using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printer.API.Models
{
    public class PrinterInfo
    {
        public OperationType operationType { get; set; }
        public string Description { get; set; }
    }

    public enum OperationType
    {
        Printed,
        Error,
        EndOfThePaper
    }
}
