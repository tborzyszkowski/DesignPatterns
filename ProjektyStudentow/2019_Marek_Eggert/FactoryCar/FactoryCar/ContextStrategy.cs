using FactoryCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryCar
{
    public class ContextStrategy
    {
        private SpeedStrategyInterface strategy = null;

        public ContextStrategy(SpeedStrategyInterface strategy)
        {
            this.strategy = strategy;
        }

        public List<Car> Calculate(List<Car> p)
        {
            return this.strategy.Count(p);
        }
    }
}
