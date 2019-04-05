import FactoryReflection.ReflectionCarFactory;
import Products.Cars.Carrera;
import Products.Cars.Civic;
import Products.Cars.M240;
import Products.Vehicle;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

import java.lang.reflect.InvocationTargetException;

import static org.junit.jupiter.api.Assertions.*;


public class ReflectionFactoryTest {

    private static ReflectionCarFactory factory;

    @BeforeAll
    public static void setUp(){
        factory = ReflectionCarFactory.getInstance();
        factory.registerType("carrera", Carrera.class);
        factory.registerType("civic", Civic.class);
        factory.registerType("m240", M240.class);
    }

    @Test
    public void CreateCarsFromReflection() throws InvocationTargetException, NoSuchMethodException, InstantiationException, IllegalAccessException {
        Vehicle carrera = factory.getCar("carrera");
        Vehicle civic = factory.getCar("civic");
        Vehicle m240 = factory.getCar("m240");

        assertAll(
                () -> assertTrue(carrera instanceof Carrera),
                () -> assertTrue(civic instanceof Civic),
                () -> assertTrue(m240 instanceof M240)
        );
    }

    @Test
    public void CreateMultipleCarreraShouldNotReturnTheSameObject() throws InvocationTargetException, NoSuchMethodException, InstantiationException, IllegalAccessException {
        Vehicle carrera1 = factory.getCar("carrera");
        Vehicle carrera2 = factory.getCar("carrera");

        assertAll(
                () -> assertEquals(carrera1.toString(), carrera2.toString()),
                () -> assertNotSame(carrera1, carrera2)
        );
    }
}
