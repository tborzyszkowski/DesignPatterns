package prototype.deep;

import java.util.HashMap;
import java.util.Map;

import builder.simple.common.BodyType;
import builder.simple.common.ChassisType;
import builder.simple.common.DriveType;
import prototype.common.CarType;
import prototype.common.Engine;
import prototype.common.FuelType;

public class CarManager {

	private Map<CarType, Car> cars = new HashMap() {{
		put(CarType.FAMILY, new Car("ford", "mondeo", BodyType.COMBI, DriveType.FRONT_WHEEL, new Engine(FuelType.GASOLINE), ChassisType.LOW_CHASIS));
		put(CarType.SPORTS, new Car("porsche", "911", BodyType.HATCHBACK, DriveType.REAR_WHEEL, new Engine(FuelType.GASOLINE), ChassisType.LOW_CHASIS));
		put(CarType.SUV, new Car("bmw", "x5", BodyType.SEDAN, DriveType.FOUR_WHEEL, new Engine(FuelType.OIL), ChassisType.HIGH_CHASIS));
	}};

	public void putNewCar(CarType carType, Car car) {
		cars.put(carType, car);
	}

	public Car getCarByCustomClone(CarType carType) {
		return cars.get(carType).customClone();
	}

	public Car getCarByDeepCloningLibClone(CarType carType) {
		return cars.get(carType).deepCloningLibraryClone();
	}

	public Car getCarBySerializationClone(CarType carType) {
		return cars.get(carType).serializationClone();
	}

}
