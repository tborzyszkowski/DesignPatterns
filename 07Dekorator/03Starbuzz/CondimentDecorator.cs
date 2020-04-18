using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Starbuzz {
	public abstract class CondimentDecorator : Beverage {
		protected Beverage beverage;

		protected CondimentDecorator(Beverage beverage)
		{
			this.beverage = beverage;
		}

		public abstract override string Description { get; }
	}
}
