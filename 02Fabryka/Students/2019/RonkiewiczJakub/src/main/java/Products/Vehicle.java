package Products;


public abstract class Vehicle {
    protected Brand brand;
    protected String model;
    protected int price;
    protected int maxSpeed;

    public abstract void build();
    public abstract void drive();

    public Brand getBrand() {
        return brand;
    }

    public String toString() {
        return (brand + " | " + model + " | ") +
                "$" + price + " | " + maxSpeed + "km/h";
    }

}
