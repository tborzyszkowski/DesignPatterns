import FactorySupplier.CarreraSupplier;
import FactorySupplier.RegistartionCarFactory;
import Products.Cars.Carrera;
import Products.Cars.Civic;
import Products.Cars.Micra;
import Products.Vehicle;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

public class RegistrationFactoryTest {
    private static RegistartionCarFactory factory;

    @BeforeAll
    public static void setUp(){
        factory = RegistartionCarFactory.getInstance();
        factory.registerSupplier("civic", Civic::new);
        factory.registerSupplier("carrera", new CarreraSupplier());
        factory.registerSupplier("micra", Micra::new);
    }

    @Test
    public void CreateCarsRegistered(){
        Vehicle carrera = factory.getCar("carrera");
        Vehicle civic = factory.getCar("civic");
        Vehicle micra = factory.getCar("micra");

        assertAll(
                () -> assertTrue(carrera instanceof Carrera),
                () -> assertTrue(civic instanceof Civic),
                () -> assertTrue(micra instanceof Micra)
        );
    }

    @Test
    public void CreateMultipleCarreraShouldNotReturnTheSameObject(){
        Vehicle carrera1 = factory.getCar("carrera");
        Vehicle carrera2 = factory.getCar("carrera");

        assertAll(
                () -> assertEquals(carrera1.toString(), carrera2.toString()),
                () -> assertNotSame(carrera1, carrera2)
        );
    }
}
