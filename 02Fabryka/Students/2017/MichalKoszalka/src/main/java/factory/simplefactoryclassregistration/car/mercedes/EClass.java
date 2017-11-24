package factory.simplefactoryclassregistration.car.mercedes;

import factory.simplefactoryclassregistration.car.CarSegment;
import factory.simplefactoryclassregistration.factory.MercedesFactory;

public class EClass implements Mercedes {

	static {
		MercedesFactory.getInstance().registerItem(CarSegment.E_SEGMENT, CClass.class);
	}

	@Override
	public String toString() {
		return "e-class";
	}

}
