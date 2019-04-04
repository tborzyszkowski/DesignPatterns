package Products;

public abstract class Bicycle extends Vehicle {

    protected float weight;

    public void repair() {
        System.out.println("Reparing bicycle: " + model);
    }

    @Override
    public void build() {
        System.out.println("Building bicycle: " + this);
    }

    @Override
    public void drive() {
        System.out.println("Driving bicycle: " + model + "\nRemember you need to use muscle power");
    }

    @Override
    public String toString() {
        return (brand + " | " + model + " | ") +
                "$" + price + " | " + maxSpeed + "km/h | " + weight +
                "kg";
    }
}
