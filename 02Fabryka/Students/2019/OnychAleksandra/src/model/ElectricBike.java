package model;

public class ElectricBike extends Bike {

    public ElectricBike() {
        brand = "Kellys";
        type = BikeType.ELECTRIC;
        wheels = "29";
        frame = "tytanowa";
        engine = true;
        parts.add("lamp");
    }

    @Override
    public Bike createBike() {
        return null;
    }
}
