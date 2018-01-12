using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    public class ContextStrategy
    {
        private CalulateStrategyInterface strategy = null;

        public ContextStrategy(CalulateStrategyInterface strategy)
        {
            this.strategy = strategy;
        }

        public List<Product> Calculate(List<Product> p)
        {
            return this.strategy.Count(p);
        }
    }
}
