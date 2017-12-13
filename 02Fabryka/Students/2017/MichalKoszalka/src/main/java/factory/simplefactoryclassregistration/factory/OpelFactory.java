package factory.simplefactoryclassregistration.factory;

import java.lang.reflect.Constructor;
import java.lang.reflect.InvocationTargetException;
import java.util.HashMap;
import java.util.Map;

import factory.common.exception.UnsupportedCarSegmentException;
import factory.simplefactoryclassregistration.car.CarSegment;
import factory.simplefactoryclassregistration.car.opel.Opel;

public class OpelFactory implements CarFactory {

	private static final OpelFactory instance = new OpelFactory();

	private Map<CarSegment, Class<? extends Opel>> registeredCars = new HashMap();

	private OpelFactory() {

	}

	public static OpelFactory getInstance() {
		return instance;
	}

	public void registerItem(CarSegment carSegment, Class<? extends Opel> car) {
		registeredCars.put(carSegment, car);
	}

	public Opel createCar(CarSegment carSegment)
			throws IllegalAccessException, InvocationTargetException, InstantiationException {
		Class<? extends Opel> clazz = registeredCars.get(carSegment);
		if(clazz != null) {
			Constructor<?> constructor = clazz.getConstructors()[0];
			return (Opel) constructor.newInstance();
		}
		throw new UnsupportedCarSegmentException(carSegment + " unsupported in opel factory");
	}

}

