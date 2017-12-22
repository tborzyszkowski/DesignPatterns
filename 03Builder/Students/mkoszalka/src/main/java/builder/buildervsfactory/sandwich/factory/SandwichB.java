package builder.buildervsfactory.sandwich.factory;

import java.util.Arrays;

import builder.buildervsfactory.sandwich.common.SandwichBase;
import builder.buildervsfactory.sandwich.enums.Bread;
import builder.buildervsfactory.sandwich.enums.Cheese;
import builder.buildervsfactory.sandwich.enums.Meat;

public class SandwichB extends SandwichBase {

	public SandwichB() {
		bread = Bread.WHOLE_GRAIN;
		meat = Meat.CHICKEN;
		cheese = Cheese.MOZZARELLA;
		vegetables = Arrays.asList("tomato", "lettuce");
	}
}
