using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Starbuzz {
    public abstract class Beverage {
        private string description = "Unknown Beverage";

        public abstract double Cost();

        public virtual string Description
        {
            get => description;
        }
    }
}
