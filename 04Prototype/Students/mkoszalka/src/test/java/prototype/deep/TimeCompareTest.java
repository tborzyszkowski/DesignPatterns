package prototype.deep;

import org.junit.jupiter.api.Test;

import builder.simple.common.BodyType;
import builder.simple.common.ChassisType;
import builder.simple.common.DriveType;
import prototype.common.Engine;
import prototype.common.FuelType;

import static org.junit.jupiter.api.Assertions.*;

public class TimeCompareTest {

	@Test
	public void custom_vs_serialization_test() throws Exception {
		Engine engine = new Engine(FuelType.GASOLINE);
		Car car = new Car("ford", "focus", BodyType.HATCHBACK, DriveType.FRONT_WHEEL, engine, ChassisType.LOW_CHASIS);

		long customStart = System.currentTimeMillis();
		for(int i = 0; i < 1000; i++) {
			car.customClone();
		}
		long timeForCustomCopy = System.currentTimeMillis() - customStart;

		long serializationStart = System.currentTimeMillis();
		for(int i = 0; i < 1000; i++) {
			car.serializationClone();
		}
		long timeForSerializationCopy = System.currentTimeMillis() - serializationStart;

		assertTrue(timeForCustomCopy < timeForSerializationCopy);
	}

	@Test
	public void custom_vs_deep_cloning_library_clone_test() throws Exception {
		Engine engine = new Engine(FuelType.GASOLINE);
		Car car = new Car("ford", "focus", BodyType.HATCHBACK, DriveType.FRONT_WHEEL, engine, ChassisType.LOW_CHASIS);

		long customStart = System.currentTimeMillis();
		for(int i = 0; i < 1000; i++) {
			car.customClone();
		}
		long timeForCustomCopy = System.currentTimeMillis() - customStart;

		long deepCloningLibraryStart = System.currentTimeMillis();
		for(int i = 0; i < 1000; i++) {
			car.deepCloningLibraryClone();
		}
		long timeForDeepCloningCopy = System.currentTimeMillis() - deepCloningLibraryStart;

		assertTrue(timeForCustomCopy < timeForDeepCloningCopy);
	}

	@Test
	public void serialization_vs_deep_cloning_library_clone_test() throws Exception {
		Engine engine = new Engine(FuelType.GASOLINE);
		Car car = new Car("ford", "focus", BodyType.HATCHBACK, DriveType.FRONT_WHEEL, engine, ChassisType.LOW_CHASIS);

		long serializationStart = System.currentTimeMillis();
		for(int i = 0; i < 1000; i++) {
			car.serializationClone();
		}
		long timeForSerialization = System.currentTimeMillis() - serializationStart;

		long deepCloningLibraryStart = System.currentTimeMillis();
		for(int i = 0; i < 1000; i++) {
			car.deepCloningLibraryClone();
		}
		long timeForDeepCloningCopy = System.currentTimeMillis() - deepCloningLibraryStart;

		assertTrue(timeForSerialization > timeForDeepCloningCopy);
	}

}
