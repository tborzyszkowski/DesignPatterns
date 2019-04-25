package factoryMethod.germanBikes;

import model.Bike;
import model.BikeType;
import model.ElectricBike;

import java.util.Arrays;

public class GermanElectricBike extends ElectricBike {

    public GermanElectricBike() {
        setBrand("Kellys");
        setWheels("29");
        setFrame("tytanowa");
        setEngine(true);
        setParts(Arrays.asList("led lamp"));
    }

    @Override
    public Bike createBike() {
        return null;
    }
}
