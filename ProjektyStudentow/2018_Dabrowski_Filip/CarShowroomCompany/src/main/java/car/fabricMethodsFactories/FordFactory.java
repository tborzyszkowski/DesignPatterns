package car.fabricMethodsFactories;

import car.cars.Car;
import car.cars.ford.*;
import car.utils.CarType;

public class FordFactory extends CarFactory {

    private static FordFactory carFactory;

    public static FordFactory getInstance() {
        if (carFactory == null) {
            carFactory = new FordFactory();
        }
        return carFactory;
    }

    Car createCar(CarType carType) {
        if (carType.equals(CarType.SPORTS_CAR)) {
            return new FordSportsCar();
        } else if (carType.equals(CarType.SEDAN)) {
            return new FordSedan();
        } else if (carType.equals(CarType.SUV)) {
            return new FordSuv();
        } else if (carType.equals(CarType.LIMO)) {
            return new FordLimo();
        } else if (carType.equals(CarType.HATCH_BAG)) {
            return new FordHatchBag();
        } else return null;
    }
}
