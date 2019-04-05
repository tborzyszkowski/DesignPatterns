package AbstractFactory;

import Products.Bicycle;
import Products.Bicycles.Cruise;
import Products.Car;
import Products.Cars.M240;
import Products.Motorcycle;
import Products.Motorcycles.HP4;

public class BMWFactory implements Factory {
    private static BMWFactory instance;

    private BMWFactory() {}

    public static BMWFactory getInstance() {
        if(instance == null)
            instance = new BMWFactory();
        return instance;
    }


    @Override
    public Car createCar() {
        return new M240();
    }

    @Override
    public Bicycle createBike() {
        return new Cruise();
    }

    @Override
    public Motorcycle createMotor() {
        return new HP4();
    }
}
