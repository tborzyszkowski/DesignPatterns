import AbstractFactory.BMWFactory;
import AbstractFactory.HondaFactory;
import AbstractFactory.Store;
import Products.Brand;
import Products.Vehicle;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

public class AbstractFactoryTest {

    private static Store hondaStore;
    private static Store bmwStore;

    @BeforeAll
    public static void setUp() {
        bmwStore = new Store(BMWFactory.getInstance());
        hondaStore = new Store(HondaFactory.getInstance());
    }

    @Test
    public void AllVehiclesFromHondaFactoryAreBrandedByHonda() {
        Vehicle car = hondaStore.BuildCar();
        Vehicle bike = hondaStore.BuildBike();
        Vehicle motor = hondaStore.BuildMotor();

        assertAll(
                () -> assertEquals(Brand.HONDA, car.getBrand()),
                () -> assertEquals(Brand.HONDA, bike.getBrand()),
                () -> assertEquals(Brand.HONDA, motor.getBrand())
        );
    }

    @Test
    public void AllVehiclesFromBMWFactoryAreBrandedByBMW() {
        Vehicle car = bmwStore.BuildCar();
        Vehicle bike = bmwStore.BuildBike();
        Vehicle motor = bmwStore.BuildMotor();

        assertAll(
                () -> assertEquals(Brand.BMW, car.getBrand()),
                () -> assertEquals(Brand.BMW, bike.getBrand()),
                () -> assertEquals(Brand.BMW, motor.getBrand())
        );
    }


}
