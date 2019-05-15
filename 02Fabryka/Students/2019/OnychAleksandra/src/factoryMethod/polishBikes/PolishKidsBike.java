package factoryMethod.polishBikes;

import model.Bike;
import model.BikeType;
import model.KidsBike;

import java.util.Arrays;

public class PolishKidsBike extends KidsBike {

    public PolishKidsBike() {
        setBrand("Kellys");
        setWheels("22");
        setFrame("aluminiowa");
        setEngine(false);
        setParts(Arrays.asList("basket"));
    }

    @Override
    public Bike createBike() {
        return null;
    }
}
