import abstractFactory.bikes.Bike;
import abstractFactory.bikes.CrossBike;
import abstractFactory.shop.GermanBikeShop;
import abstractFactory.shop.PolishBikeShop;
import model.BikeType;
import org.junit.jupiter.api.Test;

import java.util.ArrayList;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

class AbstractFactoryTest {

    private static GermanBikeShop germanShop = new GermanBikeShop();
    private static PolishBikeShop polishShop = new PolishBikeShop();

    @Test
    public void shouldReturnTheSamePartsForGermanBikes() {
        Bike cityBike = germanShop.orderBike(BikeType.CITY);
        Bike crossBike = germanShop.orderBike(BikeType.CROSS);

        assertEquals(cityBike.getLamp().getType(),crossBike.getLamp().getType());
        assertEquals(cityBike.getBell().getType(), crossBike.getBell().getType());
        assertEquals(cityBike.getBasket().getType(), crossBike.getBasket().getType());

        System.out.println(cityBike.toString());
        System.out.println(crossBike.toString());
    }

    @Test
    public void shouldReturnTheSamePartsForPolishBikes() {
        Bike mountainBike = polishShop.orderBike(BikeType.MOUNTAIN);
        Bike kidsBike = polishShop.orderBike(BikeType.KIDS);

        assertEquals(mountainBike.getLamp().getType(),kidsBike.getLamp().getType());
        assertEquals(mountainBike.getBell().getType(), kidsBike.getBell().getType());
        assertEquals(mountainBike.getBasket().getType(), kidsBike.getBasket().getType());

        System.out.println(mountainBike.toString());
        System.out.println(mountainBike.toString());
    }

    @Test
    public void shouldReturnCrossBikesWithDifferentParts() {
        Bike germanCrossBike = germanShop.orderBike(BikeType.CROSS);
        Bike polishCrossBike = polishShop.orderBike(BikeType.CROSS);

        assertTrue(germanCrossBike instanceof CrossBike);
        assertTrue(polishCrossBike instanceof CrossBike);

        assertNotEquals(germanCrossBike.getLamp().getType(),polishCrossBike.getLamp().getType());
        assertNotEquals(germanCrossBike.getBell().getType(), polishCrossBike.getBell().getType());
        assertNotEquals(germanCrossBike.getBasket().getType(), polishCrossBike.getBasket().getType());

        System.out.println(germanCrossBike.toString());
        System.out.println(germanCrossBike.toString());
    }

/*    @Test
    public void testFactoryTime() {
        List<Bike> bikes = new ArrayList<>();

        for (int i=0 ; i <1000000; i++) {
            bikes.add(germanShop.orderBike(BikeType.CROSS));
        }
    }*/

}