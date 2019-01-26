package SimpleFactory;

public abstract class Car {

    protected String brandName;
    protected String model;
    protected String type;
    protected String fuelType;
    protected int price;

    public void carDetails() {
        System.out.println("=======================================");
        System.out.println("Brand: " + brandName);
        System.out.println("Model: " + model);
        System.out.println("Type: " + type);
        System.out.println("Type: " + fuelType);
        System.out.println("Type: " + price);

        System.out.println("Creating a car.");
    }
}