package model;

public class MountainBike extends Bike {

    public MountainBike() {
        brand = "Devron";
        type = BikeType.MOUNTAIN;
        wheels = "28";
        frame = "stalowa";
        engine = false;
        parts.add("lamp");
    }

    @Override
    public Bike createBike() {
        return null;
    }
}
