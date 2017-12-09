package factory.abstractfactory.showroom;

import factory.abstractfactory.car.BasicCar;
import factory.abstractfactory.car.Car;
import factory.abstractfactory.car.EcoCar;
import factory.abstractfactory.car.SportsCar;
import factory.abstractfactory.partsfactory.CarPartsAbstractFactory;

public class DependantShowRoom {

	public static Car createCar(String item, CarPartsAbstractFactory carPartsAbstractFactory) {
		Car car = null;
		if (item.equals("eco")) {

			car = new EcoCar(carPartsAbstractFactory);
			car.setModel("Eco car");

		} else if (item.equals("basic")) {

			car = new BasicCar(carPartsAbstractFactory);
			car.setModel("Basic car");

		} else if (item.equals("sports")) {

			car = new SportsCar(carPartsAbstractFactory);
			car.setModel("Sports car");
		}

		return car;
	}

}
