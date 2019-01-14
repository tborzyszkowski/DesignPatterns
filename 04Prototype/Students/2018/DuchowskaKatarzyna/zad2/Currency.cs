using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.zad2
{
    [Serializable()]
    public class Currency
    {
        public String CurrencyName {get;set;}

        public Currency()
        {
            CurrencyName = "PLN";
        }
    }
}
