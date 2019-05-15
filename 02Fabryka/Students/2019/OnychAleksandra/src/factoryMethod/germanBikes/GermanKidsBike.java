package factoryMethod.germanBikes;

import model.Bike;
import model.BikeType;
import model.KidsBike;

import java.util.Arrays;

public class GermanKidsBike extends KidsBike {

    public GermanKidsBike() {
        setBrand("Merida");
        setWheels("20");
        setFrame("stalowa");
        setEngine(false);
        setParts(Arrays.asList("bell"));
    }

    @Override
    public Bike createBike() {
        return null;
    }
}
