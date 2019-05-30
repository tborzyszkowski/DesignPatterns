using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printer.API.Models
{
    public class Article
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string VAT { get; set; }
        public string UnitOfMeasure { get; set; }
        public decimal Price { get; set; }
    }
}
