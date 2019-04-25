package factoryMethod.polishBikes;

import model.Bike;
import model.BikeType;
import model.CrossBike;

import java.util.Arrays;

public class PolishCrossBike extends CrossBike {

    public PolishCrossBike() {
        setBrand("Arkus");
        setWheels("28");
        setFrame("aluminiowa");
        setEngine(false);
        setParts(Arrays.asList("lamp"));
    }

    @Override
    public Bike createBike() {
        return null;
    }
}
