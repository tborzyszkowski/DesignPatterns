package builder.simple;

import org.junit.jupiter.api.Test;

import builder.simple.common.BodyType;
import builder.simple.common.ChassisType;
import builder.simple.common.DriveType;
import builder.simple.common.FuelType;

import static org.junit.jupiter.api.Assertions.assertEquals;

class CarBuilderTest {

	@Test
	public void test() {
		Car car = new Car.CarBuilder().withBrand("ford").withModel("focus").withBodyType(BodyType.HATCHBACK)
				.withChasisType(ChassisType.LOW_CHASIS).withDriveType(DriveType.REAR_WHEEL)
				.withFuelType(FuelType.GASOLINE).build();
		assertEquals(car.getBrand(), "ford");
		assertEquals(car.getModel(), "focus");
		assertEquals(car.getBodyType(), BodyType.HATCHBACK);
		assertEquals(car.getChassisType(), ChassisType.LOW_CHASIS);
		assertEquals(car.getDriveType(), DriveType.REAR_WHEEL);
		assertEquals(car.getFuelType(), FuelType.GASOLINE);
	}

}