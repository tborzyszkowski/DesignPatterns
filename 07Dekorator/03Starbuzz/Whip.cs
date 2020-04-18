using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Starbuzz {
	public class Whip : CondimentDecorator {
		public Whip(Beverage beverage) : base(beverage) {
		}

		public override string Description {
			get => $"{beverage.Description}, Whip";
		}

		public override double Cost() => .10 + beverage.Cost();
	}
}
