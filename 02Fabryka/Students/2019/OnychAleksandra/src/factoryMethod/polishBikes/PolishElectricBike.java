package factoryMethod.polishBikes;

import model.Bike;
import model.BikeType;
import model.ElectricBike;

import java.util.Arrays;

public class PolishElectricBike extends ElectricBike {

    public PolishElectricBike() {
        setBrand("DHS");
        setWheels("28");
        setFrame("stalowa");
        setEngine(true);
        setParts(Arrays.asList("bell"));
    }

    @Override
    public Bike createBike() {
        return null;
    }

}
