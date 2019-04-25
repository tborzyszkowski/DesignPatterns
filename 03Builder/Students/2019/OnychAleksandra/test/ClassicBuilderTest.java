import classic.*;
import classic.enums.BikeType;
import classic.enums.FrameType;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class ClassicBuilderTest {

    private BikeBuilder builder;
    private BikeShop bikeShop = new BikeShop();

    @Test
    public void shouldReturnKidsBike() {
        builder = new KidsBikeBuilder();
        bikeShop.constructBike(builder);
        Bike bike = builder.getBike();

        assertEquals(bike.getType(), BikeType.KIDS);
        assertEquals(bike.getFrameType(), FrameType.ALUMINIOWA);
        assertEquals(bike.getWheelsSize(), 20);
        assertEquals(bike.getWheelsNumber(), 3);
        assertEquals(bike.isElectricEngine(), false);

        System.out.println(bike.toString());
    }

    @Test
    public void shouldReturnElectricBike() {
        builder = new ElectricBikeBuilder();
        bikeShop.constructBike(builder);
        Bike bike = builder.getBike();

        assertEquals(bike.getType(), BikeType.ELECTRIC);
        assertEquals(bike.getFrameType(), FrameType.TYTANOWA);
        assertEquals(bike.getWheelsSize(), 28);
        assertEquals(bike.getWheelsNumber(), 2);
        assertEquals(bike.isElectricEngine(), true);

        System.out.println(bike.toString());
    }

    @Test
    public void shouldReturnNormalBike() {
        builder = new NormalBikeBuilder();
        bikeShop.constructBike(builder);
        Bike bike = builder.getBike();

        assertEquals(bike.getType(), BikeType.NORMAL);
        assertEquals(bike.getFrameType(), FrameType.STALOWA);
        assertEquals(bike.getWheelsSize(), 26);
        assertEquals(bike.getWheelsNumber(), 2);
        assertEquals(bike.isElectricEngine(), false);

        System.out.println(bike.toString());
    }

}