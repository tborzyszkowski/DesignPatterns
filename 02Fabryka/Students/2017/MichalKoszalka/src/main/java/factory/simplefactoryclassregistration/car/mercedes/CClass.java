package factory.simplefactoryclassregistration.car.mercedes;

import factory.simplefactoryclassregistration.car.CarSegment;
import factory.simplefactoryclassregistration.factory.MercedesFactory;

public class CClass implements Mercedes {

	static {
		MercedesFactory.getInstance().registerItem(CarSegment.D_SEGMENT, CClass.class);
	}

	@Override
	public String toString() {
		return "c-class";
	}

}
