package model;

public class KidsBike extends Bike {

    public KidsBike() {
        brand = "Merida";
        type = BikeType.KIDS;
        wheels = "20";
        frame = "stalowa";
        engine = false;
        parts.add("bell");
    }

    @Override
    public Bike createBike() {
        return null;
    }
}
