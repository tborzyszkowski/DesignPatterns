import factoryClassRegistrationWithoutReflection.BikeFactory;
import factoryClassRegistrationWithoutReflection.BikeShop;
import factoryClassRegistrationWithoutReflection.ElectricBikeSupplier;
import model.*;
import org.junit.jupiter.api.Test;

import java.lang.reflect.InvocationTargetException;
import java.util.ArrayList;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

class FactoryClassRegistrationTest {

    private BikeFactory bikeFactory = BikeFactory.getInstance();
    private BikeShop bikeShop = new BikeShop(bikeFactory);

    @Test
    public void shouldReturnKidsBike() throws NoSuchMethodException, InstantiationException, IllegalAccessException, InvocationTargetException {
        bikeFactory.registerBike(BikeType.KIDS, KidsBike::new);
        Bike bike = bikeShop.makeBike(BikeType.KIDS);

        assertTrue(bike instanceof KidsBike);
        System.out.println(bike.toString());
    }

    @Test
    public void shouldReturnElectricBike() throws NoSuchMethodException, InstantiationException, IllegalAccessException, InvocationTargetException {
        bikeFactory.registerBike(BikeType.ELECTRIC, new ElectricBikeSupplier());
        Bike bike = bikeShop.makeBike(BikeType.ELECTRIC);

        assertTrue(bike instanceof ElectricBike);
        System.out.println(bike.toString());
    }

/*    @Test
    public void testFactoryTime() throws NoSuchMethodException, InstantiationException, IllegalAccessException, InvocationTargetException {
        List<Bike> bikes = new ArrayList<>();

        for (int i=0 ; i <1000000; i++) {
            bikeFactory.registerBike(BikeType.CROSS, new ElectricBikeSupplier());
            bikes.add(bikeShop.makeBike(BikeType.CROSS));
        }
    }*/
}