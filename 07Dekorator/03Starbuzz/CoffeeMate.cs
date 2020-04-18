using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Starbuzz {
	public class CoffeeMate : CondimentDecorator {
		public CoffeeMate(Beverage beverage) : base(beverage) {
		}

		public override string Description {
			get => $"{beverage.Description}, Coffee Mate";
		}

		public override double Cost() => (.15 + beverage.Cost());
	}
}
