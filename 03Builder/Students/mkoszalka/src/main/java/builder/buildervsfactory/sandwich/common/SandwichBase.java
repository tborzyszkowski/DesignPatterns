package builder.buildervsfactory.sandwich.common;

import java.util.List;

import builder.buildervsfactory.sandwich.enums.Bread;
import builder.buildervsfactory.sandwich.enums.Cheese;
import builder.buildervsfactory.sandwich.enums.Meat;

public abstract class SandwichBase {

	protected Bread bread;

	protected Meat meat;

	protected Cheese cheese;

	protected List<String> vegetables;

	public Bread getBread() {
		return bread;
	}

	public Meat getMeat() {
		return meat;
	}

	public Cheese getCheese() {
		return cheese;
	}

	public List<String> getVegetables() {
		return vegetables;
	}

}
