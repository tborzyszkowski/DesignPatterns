package factoryMethod.germanBikes;

import model.Bike;
import model.BikeType;
import model.CityBike;

import java.util.Arrays;

public class GermanCityBike extends CityBike {

    public GermanCityBike() {
        setBrand("Merida");
        setWheels("26");
        setFrame("stalowa");
        setEngine(false);
        setParts(Arrays.asList("front basket"));
    }

    @Override
    public Bike createBike() {
        return null;
    }
}
