package factory.simplefactoryclassregistration.factory;

import java.lang.reflect.InvocationTargetException;

import factory.simplefactoryclassregistration.car.Car;
import factory.simplefactoryclassregistration.car.CarSegment;

public interface CarFactory {

    public <E extends Car> E createCar(CarSegment carSegment) throws IllegalAccessException, InvocationTargetException,
			InstantiationException;

}
