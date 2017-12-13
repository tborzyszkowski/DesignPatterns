using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Starbuzz {
    public class DarkRoast : Beverage {

        public override string Description
        {
            get => "Dark Roast Coffee"; 
        }

        public override double Cost() => .99;
    }
}
