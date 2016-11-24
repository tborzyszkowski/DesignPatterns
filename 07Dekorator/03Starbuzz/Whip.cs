using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Starbuzz {
    public class Whip : CondimentDecorator {
        Beverage beverage;

        public Whip(Beverage beverage) {
            this.beverage = beverage;
        }

        public override string Description
        {
            get
            { return beverage.Description + ", Whip"; }
        }

        public override double Cost() {
            return .10 + beverage.Cost();
        }
    }
}
 