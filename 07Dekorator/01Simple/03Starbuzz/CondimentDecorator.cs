using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Starbuzz {
    public abstract class CondimentDecorator : Beverage {

        public abstract override string Description { get; }
    }
}
