import factoryClassRegistrationReflection.BikeFactory;
import factoryClassRegistrationReflection.BikeShop;
import model.Bike;
import model.BikeType;
import model.CrossBike;
import org.junit.jupiter.api.Test;

import java.lang.reflect.InvocationTargetException;
import java.util.ArrayList;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

class FactoryClassRegistrationReflectionTest {

    private BikeFactory bikeFactory = BikeFactory.getInstance();
    private BikeShop bikeShop = new BikeShop(bikeFactory);

    @Test
    public void shouldReturnCrossBike() throws NoSuchMethodException, InstantiationException, IllegalAccessException, InvocationTargetException {
        bikeFactory.registerBike(BikeType.CROSS, CrossBike.class);
        Bike bike = bikeShop.makeBike(BikeType.CROSS);
        Bike bike2 = bikeShop.makeBike(BikeType.CROSS);

        assertTrue(bike instanceof CrossBike);
        assertTrue(bike2 instanceof CrossBike);

        assertNotSame(bike, bike2);

        System.out.println(bike.toString());
        System.out.println(bike2.toString());
    }

/*    @Test
    public void testFactoryTime() throws NoSuchMethodException, InstantiationException, IllegalAccessException, InvocationTargetException {
        List<Bike> bikes = new ArrayList<>();

        for (int i=0 ; i <1000000; i++) {
            bikeFactory.registerBike(BikeType.CROSS, CrossBike.class);
            bikes.add(bikeShop.makeBike(BikeType.CROSS));
        }
    }*/

}