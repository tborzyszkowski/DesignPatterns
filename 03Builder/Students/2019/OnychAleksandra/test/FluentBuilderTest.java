import classic.enums.BikeType;
import classic.enums.FrameType;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class FluentBuilderTest {

    @Test
    public void shouldReturnElectricBike() {
        fluent.Bike bike = new fluent.Bike.Builder(BikeType.ELECTRIC)
                .electricEngine(true)
                .frameType(FrameType.TYTANOWA)
                .wheelsNumber(2)
                .wheelsSize(28)
                .build();

        assertEquals(bike.getType(), BikeType.ELECTRIC);
        assertEquals(bike.getFrameType(), FrameType.TYTANOWA);
        assertEquals(bike.getWheelsSize(), 28);
        assertEquals(bike.getWheelsNumber(), 2);
        assertEquals(bike.isElectricEngine(), true);

        System.out.println(bike.toString());
    }

    @Test
    public void shouldReturnNormalBike() {
        fluent.Bike bike = new fluent.Bike.Builder(BikeType.NORMAL)
                .electricEngine(false)
                .frameType(FrameType.STALOWA)
                .wheelsNumber(2)
                .wheelsSize(29)
                .build();

        assertEquals(bike.getType(), BikeType.NORMAL);
        assertEquals(bike.getFrameType(), FrameType.STALOWA);
        assertEquals(bike.getWheelsSize(), 29);
        assertEquals(bike.getWheelsNumber(), 2);
        assertEquals(bike.isElectricEngine(), false);

        System.out.println(bike.toString());
    }

    @Test
    public void shouldReturnKidsBike() {
        fluent.Bike bike = new fluent.Bike.Builder(BikeType.KIDS)
                .electricEngine(false)
                .frameType(FrameType.ALUMINIOWA)
                .wheelsNumber(3)
                .wheelsSize(20)
                .build();

        assertEquals(bike.getType(), BikeType.KIDS);
        assertEquals(bike.getFrameType(), FrameType.ALUMINIOWA);
        assertEquals(bike.getWheelsSize(), 20);
        assertEquals(bike.getWheelsNumber(), 3);
        assertEquals(bike.isElectricEngine(), false);

        System.out.println(bike.toString());
    }

}