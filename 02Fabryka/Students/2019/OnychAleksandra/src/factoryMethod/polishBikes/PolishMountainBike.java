package factoryMethod.polishBikes;

import model.Bike;
import model.BikeType;
import model.MountainBike;

import java.util.Arrays;

public class PolishMountainBike extends MountainBike {

    public PolishMountainBike() {
        setBrand("Devron");
        setWheels("28");
        setFrame("tytanowa");
        setEngine(false);
        setParts(Arrays.asList("led lamp"));
    }

    @Override
    public Bike createBike() {
        return null;
    }
}
