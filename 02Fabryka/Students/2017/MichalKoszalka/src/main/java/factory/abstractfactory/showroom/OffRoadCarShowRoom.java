package factory.abstractfactory.showroom;

import factory.abstractfactory.car.BasicCar;
import factory.abstractfactory.car.Car;
import factory.abstractfactory.car.EcoCar;
import factory.abstractfactory.car.SportsCar;
import factory.abstractfactory.partsfactory.CarPartsAbstractFactory;
import factory.abstractfactory.partsfactory.OffRoadCarPartsFactory;

public class OffRoadCarShowRoom extends ShowRoom{

	protected Car createCar(String item) {
		Car car = null;
		CarPartsAbstractFactory carPartsFactory =
				new OffRoadCarPartsFactory();

		if (item.equals("eco")) {

			car = new EcoCar(carPartsFactory);
			car.setModel("Eco off road car");

		} else if (item.equals("basic")) {

			car = new BasicCar(carPartsFactory);
			car.setModel("Basic off road car");

		} else if (item.equals("sports")) {

			car = new SportsCar(carPartsFactory);
			car.setModel("Sports off road car");
		}

		return car;
	}

}
