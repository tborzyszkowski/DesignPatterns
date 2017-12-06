using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Starbuzz {
    public class HouseBlend : Beverage {
        public override string Description
        {
            get => "House Blend Coffee"; 
        }

        public override double Cost() => .89;
    }
}
