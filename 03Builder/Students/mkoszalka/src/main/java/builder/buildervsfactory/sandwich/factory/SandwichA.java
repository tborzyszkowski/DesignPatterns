package builder.buildervsfactory.sandwich.factory;

import java.util.Arrays;

import builder.buildervsfactory.sandwich.common.SandwichBase;
import builder.buildervsfactory.sandwich.enums.Bread;
import builder.buildervsfactory.sandwich.enums.Cheese;
import builder.buildervsfactory.sandwich.enums.Meat;

public class SandwichA extends SandwichBase {

	public SandwichA() {
		bread = Bread.RYE;
		meat = Meat.BEEF;
		cheese = Cheese.GOUDA;
		vegetables = Arrays.asList("cucumber", "olives");
	}

}
