package factory.simplefactoryclassregistration.factory;

import java.lang.reflect.Constructor;
import java.lang.reflect.InvocationTargetException;
import java.util.HashMap;
import java.util.Map;

import factory.common.exception.UnsupportedCarSegmentException;
import factory.simplefactoryclassregistration.car.CarSegment;
import factory.simplefactoryclassregistration.car.mercedes.Mercedes;

public class MercedesFactory implements CarFactory {

	private static final MercedesFactory instance = new MercedesFactory();

	private Map<CarSegment, Class<? extends Mercedes>> registeredCars = new HashMap();

	private MercedesFactory() {

	}

	public static MercedesFactory getInstance() {
		return instance;
	}

	public void registerItem(CarSegment carSegment, Class<? extends Mercedes> car) {
		registeredCars.put(carSegment, car);
	}

	public Mercedes createCar(CarSegment carSegment)
			throws IllegalAccessException, InvocationTargetException, InstantiationException {
		Class<? extends Mercedes> clazz = registeredCars.get(carSegment);
		if(clazz != null) {
			Constructor<?> constructor = clazz.getConstructors()[0];
			return (Mercedes) constructor.newInstance();
		}
		throw new UnsupportedCarSegmentException(carSegment + " unsupported in mercedes factory");
	}

}

