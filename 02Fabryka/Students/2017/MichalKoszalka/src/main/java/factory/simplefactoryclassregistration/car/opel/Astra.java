package factory.simplefactoryclassregistration.car.opel;

import factory.simplefactoryclassregistration.car.CarSegment;
import factory.simplefactoryclassregistration.factory.OpelFactory;

public class Astra implements Opel {

	static {
		OpelFactory.getInstance().registerItem(CarSegment.C_SEGMENT, Astra.class);
	}

	@Override
	public String toString() {
		return "astra";
	}

}
