package AbstractFactory;

import Products.Bicycle;
import Products.Car;
import Products.Motorcycle;

public interface Factory {
    Car createCar();
    Bicycle createBike();
    Motorcycle createMotor();
}
