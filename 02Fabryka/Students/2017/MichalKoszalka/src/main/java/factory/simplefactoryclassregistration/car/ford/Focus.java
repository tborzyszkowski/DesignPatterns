package factory.simplefactoryclassregistration.car.ford;

import factory.simplefactoryclassregistration.car.CarSegment;
import factory.simplefactoryclassregistration.factory.FordFactory;

public class Focus implements Ford {

	static {
		FordFactory.getInstance().registerItem(CarSegment.C_SEGMENT, Focus.class);
	}

	@Override
	public String toString() {
		return "focus";
	}

}
