import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class PrototypeTest {

    BikeManager bikeManager = new BikeManager();

    @Test
    public void deepPrototype() {
        Bike b1 = bikeManager.getBikePrototype("kids");
        Bike b2 = bikeManager.getBikePrototype("kids");

        System.out.println("----- DEEP COPY -----");
        System.out.println("Bike1 : " + b1);
        System.out.println("Bike2 : " + b2 + "\n");

        assertNotSame(b1, b2);
        assertNotSame(b1.getWheel(), b2.getWheel());
        assertNotSame(b1.getFrame(), b2.getFrame());
        assertNotSame(b1.getFrame().getType(), b2.getFrame().getType());

        b1.setType("electric");
        b1.getWheel().setSize(26);
        b1.getFrame().setSize(32);
        b1.getFrame().getType().setName("tytanowa");

        System.out.println("Bike1 : " + b1);
        System.out.println("Bike2 : " + b2 + "\n");
    }

    @Test
    public void shallowPrototype() {
        Bike b1 = bikeManager.getBikeShallowCopy("kids");
        Bike b2 = bikeManager.getBikeShallowCopy("kids");

        System.out.println("----- SHALLOW COPY -----");
        System.out.println("Bike1 : " + b1);
        System.out.println("Bike2 : " + b2 + "\n");

        assertNotSame(b1, b2);
        assertSame(b1.getWheel(), b2.getWheel());
        assertSame(b1.getFrame(), b2.getFrame());
        assertSame(b1.getFrame().getType(), b2.getFrame().getType());

        b1.setType("electric");
        b1.getWheel().setSize(26);
        b1.getFrame().setSize(32);
        b1.getFrame().getType().setName("tytanowa");

        System.out.println("Bike1 : " + b1);
        System.out.println("Bike2 : " + b2 + "\n");
    }
}