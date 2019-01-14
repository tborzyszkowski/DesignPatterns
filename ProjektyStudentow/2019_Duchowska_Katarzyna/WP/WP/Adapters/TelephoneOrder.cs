using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Adapters
{
    public class TelephoneOrder
    {
        public String DrinkName { get; set; }

        public TelephoneOrder(String drinkName)
        {
            DrinkName = drinkName;
        }
    }
}
