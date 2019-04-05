package Products;

public abstract class Motorcycle extends Vehicle {

    public void fuel() {
        System.out.println("Refueling motorcycle: " + model);
    }

    public void wheelie(){
        System.out.println("Driving only on rear wheel right now");
    }

    @Override
    public void build() {
        System.out.println("Building Motorcycle: " + this);
    }

    @Override
    public void drive() {
        System.out.println("Driving Motorcycle: " + model);
    }
}
