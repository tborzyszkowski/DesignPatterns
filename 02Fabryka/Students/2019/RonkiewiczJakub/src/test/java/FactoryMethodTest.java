import FactoryMethod.BikeStore;
import FactoryMethod.CarStore;
import FactoryMethod.MotorStore;
import Products.Bicycles.Endurace;
import Products.Cars.Micra;
import Products.Motorcycles.CBR;
import Products.Vehicle;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

public class FactoryMethodTest {

    private static BikeStore bikeStore;
    private static CarStore carStore;
    private static MotorStore motorStore;

    @BeforeAll
    public static void setUp(){
        bikeStore = BikeStore.getInstance();
        carStore = CarStore.getInstance();
        motorStore = MotorStore.getInstance();
    }

    @Test
    public void CreateSpecificVehiclesFromSpecificStores() {
        Vehicle bike = bikeStore.Build("endurace");
        Vehicle car = carStore.Build("micra");
        Vehicle motor = motorStore.Build("cbr");

        assertAll(
                () -> assertTrue(bike instanceof Endurace),
                () -> assertTrue(car instanceof Micra),
                () -> assertTrue(motor instanceof CBR)
        );
    }

    @Test
    public void CreateExistingCarFromBikeOrMotorStoreShouldReturnNull() {
        Vehicle carFromBike = bikeStore.Build("carrera");
        Vehicle carFromMotor = motorStore.Build("carrera");

        assertAll(
                () -> assertNull(carFromBike),
                () -> assertNull(carFromMotor)
        );
    }
}
