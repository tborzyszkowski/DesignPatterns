package factory.simplefactoryclassregistration.car.ford;

import factory.simplefactoryclassregistration.car.CarSegment;
import factory.simplefactoryclassregistration.factory.FordFactory;

public class Mondeo implements Ford {

	static {
		FordFactory.getInstance().registerItem(CarSegment.D_SEGMENT, Mondeo.class);
	}

	@Override
	public String toString() {
		return "mondeo";
	}

}
