import model.*;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;
import simple.SimpleBikeFactory;
import simple.SimpleBikeShop;

import java.util.ArrayList;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

class SimpleFactoryTest {

    private static SimpleBikeShop bikeShop;

    @BeforeAll
    public static void setUp() {
        SimpleBikeFactory bikeFactory = SimpleBikeFactory.getInstance();
        bikeShop = new SimpleBikeShop(bikeFactory);
    }

    @Test
    public void shouldReturnCityBike() {
        Bike bike = bikeShop.makeBike(BikeType.CITY);

        assertTrue(bike instanceof CityBike);
        System.out.println(bike.toString());
    }

    @Test
    public void shouldReturnCrossBike() {
        Bike bike = bikeShop.makeBike(BikeType.CROSS);

        assertTrue(bike instanceof CrossBike);
        System.out.println(bike.toString());
    }

    @Test
    public void shouldReturnElectricBike() {
        Bike bike = bikeShop.makeBike(BikeType.ELECTRIC);

        assertTrue(bike instanceof ElectricBike);
        System.out.println(bike.toString());
    }

    @Test
    public void shouldReturnKidsBike() {
        Bike bike = bikeShop.makeBike(BikeType.KIDS);

        assertTrue(bike instanceof KidsBike);
        System.out.println(bike.toString());
    }

    @Test
    public void shouldReturnMountainBike() {
        Bike bike = bikeShop.makeBike(BikeType.MOUNTAIN);

        assertTrue(bike instanceof MountainBike);
        System.out.println(bike.toString());
    }

/*    @Test
    public void testFactoryTime() {
        List<Bike> bikes = new ArrayList<>();

        for (int i=0 ; i <1000000; i++) {
            bikes.add(bikeShop.makeBike(BikeType.CROSS));
        }
    }*/
}