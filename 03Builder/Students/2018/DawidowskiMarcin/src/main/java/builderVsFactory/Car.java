package builderVsFactory;

public abstract class Car {
    public String brandName;
    public String model;
    public String type;
    public String fuelType;
    public int price;

    @Override
    public String toString() {
        return  "Brand = " + brandName +
                ", model = " + model +
                ", type = " + type +
                ", fuel type = " + fuelType +
                ", price = " + price;
    }

}
