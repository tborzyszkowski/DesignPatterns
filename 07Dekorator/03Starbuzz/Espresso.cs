using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Starbuzz {
    public class Espresso : Beverage {

        public override string Description
        {
            get => "Expresso"; 
        }

        public override double Cost()  => 1.99;
    }
}
