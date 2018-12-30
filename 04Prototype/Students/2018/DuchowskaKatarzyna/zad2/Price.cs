using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.zad2
{
    [Serializable()]
    public class Price
    {
        public double Amount { get; set; }
        public Currency Currency { get; set; }

        public Price(double amount)
        {
            Amount = amount;
            Currency = new Currency();
        }
    }
}
