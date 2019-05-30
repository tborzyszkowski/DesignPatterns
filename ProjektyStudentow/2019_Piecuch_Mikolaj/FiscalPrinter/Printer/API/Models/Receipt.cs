using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printer.API.Models
{
    public class Receipt
    {
        public int SystemNumber { get; set; }
        public string Header { get; set; }
        public List<Article> Articles { get; set; }
    }
}
