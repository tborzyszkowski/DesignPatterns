package factoryMethod.germanBikes;

import model.Bike;
import model.BikeType;
import model.CrossBike;

import java.util.Arrays;

public class GermanCrossBike extends CrossBike {

    public GermanCrossBike() {
        setBrand("Kellys");
        setWheels("29");
        setFrame("stalowa");
        setEngine(false);
        setParts(Arrays.asList("bell"));
    }

    @Override
    public Bike createBike() {
        return null;
    }
}
