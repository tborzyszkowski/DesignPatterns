package fabricMethodsFactories;

import cars.Car;
import cars.audi.*;
import utils.CarType;

public class AudiFactory extends CarFactory {

    private static AudiFactory audiFactory;

    public static AudiFactory getInstance() {
        if (audiFactory == null) {
            audiFactory = new AudiFactory();
        }
        return audiFactory;
    }

    Car createCar(CarType carType) {
        if (carType.equals(CarType.SPORTS_CAR)) {
            return new AudiSportsCar();
        } else if (carType.equals(CarType.SEDAN)) {
            return new AudiSedan();
        } else if (carType.equals(CarType.SUV)) {
            return new AudiSuv();
        } else if (carType.equals(CarType.LIMO)) {
            return new AudiLimo();
        } else if (carType.equals(CarType.HATCH_BAG)) {
            return new AudiHatchBag();
        } else return null;
    }
}
