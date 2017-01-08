using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proxy
{
    interface IActualPrices
    {
        string GoldPrice
        {
            get;
        }

        string SilverPrice
        {
            get;
        }

        string DollarToZloty
        {
            get;
        }
    }
}
