package factory.simplefactoryclassregistration.car.opel;

import factory.simplefactoryclassregistration.car.CarSegment;
import factory.simplefactoryclassregistration.factory.OpelFactory;

public class Insignia implements Opel {

	static {
		OpelFactory.getInstance().registerItem(CarSegment.E_SEGMENT, Insignia.class);
	}

	@Override
	public String toString() {
		return "insignia";
	}

}
