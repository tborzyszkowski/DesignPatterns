using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Starbuzz {
	public class Mocha : CondimentDecorator {
		public Mocha(Beverage beverage) : base(beverage){
		}

		public override string Description {
			get => $"{beverage.Description}, Mocha";
		}

		public override double Cost() => .20 + beverage.Cost();
	}
}
