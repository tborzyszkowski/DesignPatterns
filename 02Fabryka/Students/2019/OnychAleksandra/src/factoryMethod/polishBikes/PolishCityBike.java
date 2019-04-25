package factoryMethod.polishBikes;

import model.Bike;
import model.BikeType;
import model.CityBike;

import java.util.Arrays;

public class PolishCityBike extends CityBike {

    public PolishCityBike() {
        setBrand("Devron");
        setWheels("28");
        setFrame("aluminiowa");
        setEngine(false);
        setParts(Arrays.asList("back basket"));
    }

    @Override
    public Bike createBike() {
        return null;
    }
}
