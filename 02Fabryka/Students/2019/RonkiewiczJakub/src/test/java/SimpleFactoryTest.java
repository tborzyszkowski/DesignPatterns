import static org.junit.jupiter.api.Assertions.*;
import Products.Cars.Civic;
import Products.Vehicle;
import SimpleFactory.VehicleStore;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

public class SimpleFactoryTest {

    private static VehicleStore store;

    @BeforeAll
    public static void setUp(){
        store = new VehicleStore();
    }

    @Test
    public void CreateCarThatExistShouldReturnConcreteCar() {
        Vehicle car = store.OrderCar("civic");
        assertTrue(car instanceof Civic);
    }

    @Test
    public void CreateBikeThatDoesntExistShouldReturnNull() {
        Vehicle bike = store.OrderBike("Specialized");
        assertNull(bike);
    }
}
