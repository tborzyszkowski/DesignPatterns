package model;

public class CrossBike extends Bike {

    public CrossBike() {
        brand = "Arkus";
        type = BikeType.CROSS;
        wheels = "28";
        frame = "aluminiowa";
        engine = false;
        parts.add("bell");
    }

    @Override
    public Bike createBike() {
        return null;
    }
}
