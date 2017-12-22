package builder.buildervsfactory.sandwich.factory;

import builder.buildervsfactory.sandwich.common.SandwichBase;

public class SandwichBFactory implements SandwichFactoryBase {

	@Override
	public SandwichBase getSandwich() {
		return new SandwichB();
	}
}
