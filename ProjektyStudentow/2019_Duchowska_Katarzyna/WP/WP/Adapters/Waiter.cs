using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Drinks.Alcohols;
using WP.Drinks.Softs;

namespace WP.Adapters
{
    public class Waiter
    {
        public String[] Alcohols = { "Vodka", "Gin", "Rum" };
        public String[] Softs = { "Juice", "Tonic", "Cola" };

        public (String, String) GetOrder()
        {
            Random rand = new Random();
            int index = rand.Next(Alcohols.Length);

            return (Alcohols[index], Softs[index]);
        }
    }
}
