using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proxy
{
    class ActualPrices : IActualPrices
    {
        public string GoldPrice
        {
            get
            {
                // This value should come from a DB typically
                return "4 756,92";
            }
        }

        public string SilverPrice
        {
            get
            {
                // This value should come from a DB typically
                return "190,52";
            }
        }

        public string DollarToZloty
        {
            get
            {
                // This value should come from a DB typically
                return "4.12";
            }
        }
    }
}
