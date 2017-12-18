package builder.buildervsfactory.sandwich.builder;

import java.util.List;

import builder.buildervsfactory.sandwich.common.SandwichBase;
import builder.buildervsfactory.sandwich.enums.Bread;
import builder.buildervsfactory.sandwich.enums.Cheese;
import builder.buildervsfactory.sandwich.enums.Meat;

public class Sandwich extends SandwichBase {

	private Sandwich(SandwichBuilder sandwichBuilder) {
		bread = sandwichBuilder.bread;
		meat = sandwichBuilder.meat;
		cheese = sandwichBuilder.cheese;
		vegetables = sandwichBuilder.vegetables;
	}

	public static class SandwichBuilder {

		private Bread bread;

		private Meat meat;

		private Cheese cheese;

		private List<String> vegetables;

		public SandwichBuilder withBread(Bread bread) {
			this.bread = bread;
			return this;
		}

		public SandwichBuilder withMeat(Meat meat) {
			this.meat = meat;
			return this;
		}

		public SandwichBuilder withCheese(Cheese cheese) {
			this.cheese = cheese;
			return this;
		}

		public SandwichBuilder withVegetables(List<String> vegetables) {
			this.vegetables = vegetables;
			return this;
		}

		public Sandwich build() {
			return new Sandwich(this);
		}


	}
}
