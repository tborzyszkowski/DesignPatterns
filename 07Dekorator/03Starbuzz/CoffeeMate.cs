using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Starbuzz {
    public class CoffeeMate : CondimentDecorator {
        private Beverage beverage;

        public CoffeeMate(Beverage beverage) {
            this.beverage = beverage;
        }

        public override string Description
        {
            get => $"{beverage.Description}, Coffee Mate"; 
        }

        public override double Cost() => (.15 + beverage.Cost());
    }
}
