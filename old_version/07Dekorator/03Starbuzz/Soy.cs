using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Starbuzz {
	public class Soy : CondimentDecorator {
		public Soy(Beverage beverage) : base(beverage) {
		}

		public override string Description {
			get => $"{beverage.Description}, Soy";
		}

		public override double Cost() => .15 + beverage.Cost();
	}
}
