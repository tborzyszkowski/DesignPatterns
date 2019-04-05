package Products;

public abstract class Car extends Vehicle {

    protected Body body;

    public void fuel() {
        System.out.println("Refueling: " + model);
    }

    @Override
    public void build() {
        System.out.println("Building Car: " + this);
    }

    @Override
    public void drive() {
        System.out.println("Driving Car: " + model);
    }
}
