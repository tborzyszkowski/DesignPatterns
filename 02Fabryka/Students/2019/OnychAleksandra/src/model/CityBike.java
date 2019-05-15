package model;

public class CityBike extends Bike {

    public CityBike() {
        brand = "Devron";
        type = BikeType.CITY;
        wheels = "26";
        frame = "aluminiowa";
        engine = false;
        parts.add("basket");
    }

    @Override
    public Bike createBike() {
        return null;
    }
}
