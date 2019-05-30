using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printer.API.Models
{
    public class PrinterConfiguration
    {
        public string Port { get; set; } = "COM1";
        public int Speed { get; set; } = 9600;
        public Parity Parity { get; set; } = Parity.Even;
        public StopBits StopBits { get; set; } = StopBits.None;
    }
}
