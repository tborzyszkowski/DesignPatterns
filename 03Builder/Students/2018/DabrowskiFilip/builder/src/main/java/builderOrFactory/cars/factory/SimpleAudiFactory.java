package builderOrFactory.cars.factory;

import builderOrFactory.cars.Car;
import builderOrFactory.cars.CarType;
import builderOrFactory.cars.factory.audi.*;

public class SimpleAudiFactory {

    private static SimpleAudiFactory simpleAudiFactory;

    public static SimpleAudiFactory getInstance() {
        if (simpleAudiFactory == null) {
            simpleAudiFactory = new SimpleAudiFactory();
        }
        return simpleAudiFactory;
    }

    public Car createCar(CarType carType) {
        if (carType.equals(CarType.SPORTS_CAR)) {
            return new AudiSportsCar();
        } else if (carType.equals(CarType.SEDAN)) {
            return new AudiSedan();
        } else if (carType.equals(CarType.SUV)) {
            return new AudiSuv();
        } else return null;
    }
}
