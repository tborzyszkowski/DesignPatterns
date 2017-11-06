package factory.abstractfactory.showroom;

import factory.abstractfactory.car.Car;

public abstract class ShowRoom {

	protected abstract Car createCar(String item);

	public Car orderCar(String type) {
		Car car = createCar(type);
		System.out.println("Making a car " + car.getModel());
		car.prepare();
		car.refuel();
		car.prepareTires();

		return car;
	}

}
