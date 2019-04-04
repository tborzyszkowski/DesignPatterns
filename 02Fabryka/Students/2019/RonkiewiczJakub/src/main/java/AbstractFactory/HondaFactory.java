package AbstractFactory;

import Products.Bicycle;
import Products.Bicycles.SilverBullet;
import Products.Car;
import Products.Cars.Civic;
import Products.Motorcycle;
import Products.Motorcycles.CBR;

public class HondaFactory implements Factory{
    private static HondaFactory instance;

    private HondaFactory() {}

    public static HondaFactory getInstance() {
        if(instance == null)
            instance = new HondaFactory();
        return instance;
    }


    @Override
    public Car createCar() {
        return new Civic();
    }

    @Override
    public Bicycle createBike() {
        return new SilverBullet();
    }

    @Override
    public Motorcycle createMotor() {
        return new CBR();
    }
}
