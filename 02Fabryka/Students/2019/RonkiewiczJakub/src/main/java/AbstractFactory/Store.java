package AbstractFactory;

import Products.Bicycle;
import Products.Car;
import Products.Motorcycle;

public class Store {
    private Factory factory;

    public Store(Factory factory){
        this.factory = factory;
    }

    public Car BuildCar(){
        return factory.createCar();
    }

    public Bicycle BuildBike(){
        return factory.createBike();
    }

    public Motorcycle BuildMotor() {
        return factory.createMotor();
    }

}
