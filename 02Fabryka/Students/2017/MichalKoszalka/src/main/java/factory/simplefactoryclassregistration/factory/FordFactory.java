package factory.simplefactoryclassregistration.factory;

import java.lang.reflect.Constructor;
import java.lang.reflect.InvocationTargetException;
import java.util.HashMap;
import java.util.Map;

import factory.common.exception.UnsupportedCarSegmentException;
import factory.simplefactoryclassregistration.car.CarSegment;
import factory.simplefactoryclassregistration.car.ford.Ford;

public class FordFactory implements CarFactory {

	private static final FordFactory instance = new FordFactory();

	private Map<CarSegment, Class<? extends Ford>> registeredCars = new HashMap();

	private FordFactory() {

	}

	public static FordFactory getInstance() {
		return instance;
	}

	public void registerItem(CarSegment carSegment, Class<? extends Ford> car) {
		registeredCars.put(carSegment, car);
	}

	public Ford createCar(CarSegment carSegment)
			throws IllegalAccessException, InvocationTargetException, InstantiationException {
		Class<? extends Ford> clazz = registeredCars.get(carSegment);
		if(clazz != null) {
			Constructor<?> constructor = clazz.getConstructors()[0];
			return (Ford) constructor.newInstance();
		}
		throw new UnsupportedCarSegmentException(carSegment + " unsupported in ford factory");
	}

}
