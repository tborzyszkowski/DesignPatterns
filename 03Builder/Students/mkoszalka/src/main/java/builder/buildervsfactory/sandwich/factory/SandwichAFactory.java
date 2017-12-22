package builder.buildervsfactory.sandwich.factory;

import builder.buildervsfactory.sandwich.common.SandwichBase;

public class SandwichAFactory implements SandwichFactoryBase {

	@Override
	public SandwichBase getSandwich() {
		return new SandwichA();
	}
}
