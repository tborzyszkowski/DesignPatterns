package factory.abstractfactory.showroom;

import factory.abstractfactory.car.BasicCar;
import factory.abstractfactory.car.Car;
import factory.abstractfactory.car.EcoCar;
import factory.abstractfactory.car.SportsCar;
import factory.abstractfactory.partsfactory.CarPartsAbstractFactory;
import factory.abstractfactory.partsfactory.MuscleCarPartsFactory;

public class MuscleCarShowRoom extends ShowRoom{

	protected Car createCar(String item) {
		Car car = null;
		CarPartsAbstractFactory carPartsFactory =
				new MuscleCarPartsFactory();

		if (item.equals("eco")) {

			car = new EcoCar(carPartsFactory);
			car.setModel("Eco muscle car");

		} else if (item.equals("basic")) {

			car = new BasicCar(carPartsFactory);
			car.setModel("Basic muscle car");

		} else if (item.equals("sports")) {

			car = new SportsCar(carPartsFactory);
			car.setModel("Sports muscle car");
		}

		return car;
	}

}