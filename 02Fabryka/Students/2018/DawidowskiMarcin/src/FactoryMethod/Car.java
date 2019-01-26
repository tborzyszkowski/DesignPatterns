package FactoryMethod;

public abstract class Car {
    protected String brandName;
    protected String model;
    protected String type;
    protected String fuelType;
    protected int price;

    @Override
    public String toString() {
        return  "name = " + brandName +
                ", model = " + model +
                ", type = " + type +
                ", fuel type = " + fuelType +
                ", price = " + price;
    }
}

