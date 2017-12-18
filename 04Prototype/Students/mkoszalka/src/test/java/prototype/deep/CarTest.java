package prototype.deep;

import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

import builder.simple.common.BodyType;
import builder.simple.common.ChassisType;
import builder.simple.common.DriveType;
import prototype.common.CarType;
import prototype.common.Engine;
import prototype.common.FuelType;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertNotEquals;

class CarTest {

	static Car car;
	static CarManager carManager;

	@BeforeAll
	public static void beforeAll() {
		Engine engine = new Engine(FuelType.GASOLINE);
		car = new Car("ford", "focus", BodyType.HATCHBACK, DriveType.FRONT_WHEEL, engine, ChassisType.LOW_CHASIS);
		carManager = new CarManager();
		carManager.putNewCar(CarType.CUSTOM, car);
	}

	@Test
	public void customClone_test() {
		Car copy = carManager.getCarByCustomClone(CarType.CUSTOM);

		assertNotEquals(car, copy);
		assertEquals(car.getBrand(), copy.getBrand());
		assertEquals(car.getModel(), copy.getModel());
		assertEquals(car.getBodyType(), copy.getBodyType());
		assertEquals(car.getDriveType(), copy.getDriveType());
		assertEquals(car.getChassisType(), copy.getChassisType());
		assertEquals(car.getEngine().getFuelType(), copy.getEngine().getFuelType());
		assertNotEquals(car.getEngine(), copy.getEngine());
	}

	@Test
	public void serializationClone_test() throws Exception {
		Car copy = carManager.getCarBySerializationClone(CarType.CUSTOM);

		assertNotEquals(car, copy);
		assertEquals(car.getBrand(), copy.getBrand());
		assertEquals(car.getModel(), copy.getModel());
		assertEquals(car.getBodyType(), copy.getBodyType());
		assertEquals(car.getDriveType(), copy.getDriveType());
		assertEquals(car.getChassisType(), copy.getChassisType());
		assertEquals(car.getEngine().getFuelType(), copy.getEngine().getFuelType());
		assertNotEquals(car.getEngine(), copy.getEngine());
	}

	@Test
	public void deepCloningLibraryClone_test() throws Exception {
		Car copy = carManager.getCarByDeepCloningLibClone(CarType.CUSTOM);

		assertNotEquals(car, copy);
		assertEquals(car.getBrand(), copy.getBrand());
		assertEquals(car.getModel(), copy.getModel());
		assertEquals(car.getBodyType(), copy.getBodyType());
		assertEquals(car.getDriveType(), copy.getDriveType());
		assertEquals(car.getChassisType(), copy.getChassisType());
		assertEquals(car.getEngine().getFuelType(), copy.getEngine().getFuelType());
		assertNotEquals(car.getEngine(), copy.getEngine());
	}

}