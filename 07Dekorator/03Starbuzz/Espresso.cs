using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Starbuzz {
    public class Espresso : Beverage {

        public override string Description
        {
            get { return "Expresso"; }
        }

        public override double Cost() {
            return 1.99;
        }
    }
}
