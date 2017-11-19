package factory.abstractfactory.car;

import factory.abstractfactory.partsfactory.CarPartsAbstractFactory;

public class SportsCar extends Car {

	CarPartsAbstractFactory carPartsFactory;

	public SportsCar(CarPartsAbstractFactory carPartsFactory) {
		this.carPartsFactory = carPartsFactory;
	}

	public void prepare() {
		System.out.println("Preparing " + model);
		engine = carPartsFactory.createEngine();
		chassis = carPartsFactory.createChassis();
		drive = carPartsFactory.createDrive();
		body = carPartsFactory.createBody();
		turboCharger = carPartsFactory.createTurboCharger();
	}
}
