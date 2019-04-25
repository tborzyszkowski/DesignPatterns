package factoryMethod.germanBikes;

import model.Bike;
import model.BikeType;
import model.MountainBike;

import java.util.Arrays;

public class GermanMountainBike extends MountainBike {

    public GermanMountainBike() {
        setBrand("DHS");
        setWheels("28");
        setFrame("tytanowa");
        setEngine(false);
        setParts(Arrays.asList("lamp"));
    }

    @Override
    public Bike createBike() {
        return null;
    }
}
