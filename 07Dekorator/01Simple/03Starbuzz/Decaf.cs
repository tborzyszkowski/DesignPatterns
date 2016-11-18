using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Starbuzz {
    public class Decaf : Beverage {

        public override string Description
        {
            get { return "Decaf Coffee"; }
        }

        public override double Cost() {
            return 1.05;
        }
    }
}
