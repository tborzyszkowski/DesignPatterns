package FactoryMethod;

public abstract class CarFactoryMethod {

    abstract Car getCar(String model);

    public Car showCar(String brand) {
        Car car = getCar(brand);
        return car;
    }
}
