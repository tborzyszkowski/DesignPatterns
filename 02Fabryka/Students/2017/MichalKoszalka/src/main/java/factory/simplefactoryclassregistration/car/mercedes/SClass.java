package factory.simplefactoryclassregistration.car.mercedes;

import factory.simplefactoryclassregistration.car.CarSegment;
import factory.simplefactoryclassregistration.factory.MercedesFactory;

public class SClass implements Mercedes {

	static {
		MercedesFactory.getInstance().registerItem(CarSegment.F_SEGMENT, SClass.class);
	}

	@Override
	public String toString() {
		return "s-class";
	}

}
