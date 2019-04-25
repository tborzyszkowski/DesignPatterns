import factoryMethod.factory.GermanBikeFactory;
import factoryMethod.factory.PolishBikeFactory;
import model.Bike;
import model.BikeType;
import model.CrossBike;
import org.junit.jupiter.api.Test;

import java.util.ArrayList;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

class FactoryMethodTest {

    private static GermanBikeFactory germanFactory = GermanBikeFactory.getInstance();;
    private static PolishBikeFactory polishFactory = PolishBikeFactory.getInstance();

    @Test
    public void shouldReturnCrossBikesWithDifferentBrands() {
        Bike polishBike = polishFactory.orderBike(BikeType.CROSS);
        Bike germanBike = germanFactory.orderBike(BikeType.CROSS);

        assertTrue(polishBike instanceof CrossBike);
        assertTrue(germanBike instanceof CrossBike);

        assertNotEquals(polishBike.getBrand(), germanBike.getBrand());

        System.out.println(polishBike.toString());
        System.out.println(germanBike.toString());
    }

/*    @Test
    public void testFactoryTime() {
        List<Bike> bikes = new ArrayList<>();

        for (int i=0 ; i <1000000; i++) {
            bikes.add(germanFactory.orderBike(BikeType.CROSS));
        }
    }*/

}