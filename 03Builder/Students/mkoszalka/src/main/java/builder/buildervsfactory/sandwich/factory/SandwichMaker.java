package builder.buildervsfactory.sandwich.factory;

import builder.buildervsfactory.sandwich.common.SandwichBase;

public class SandwichMaker {

	public SandwichBase makeSandwich(SandwichFactoryBase sandwichFactoryBase) {
		return sandwichFactoryBase.getSandwich();
	}

}
