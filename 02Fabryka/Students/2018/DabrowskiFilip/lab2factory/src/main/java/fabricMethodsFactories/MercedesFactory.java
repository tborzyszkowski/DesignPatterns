package fabricMethodsFactories;

import cars.Car;
import cars.mercedes.*;
import utils.CarType;

public class MercedesFactory extends CarFactory {

    private static MercedesFactory mercedesFactory;

    public static MercedesFactory getInstance() {
        if (mercedesFactory == null) {
            mercedesFactory = new MercedesFactory();
        }
        return mercedesFactory;
    }

    Car createCar(CarType carType) {
        if (carType.equals(CarType.SPORTS_CAR)) {
            return new MercedesSportsCar();
        } else if (carType.equals(CarType.SEDAN)) {
            return new MercedesSedan();
        } else if (carType.equals(CarType.SUV)) {
            return new MercedesSuv();
        } else if (carType.equals(CarType.LIMO)) {
            return new MercedesLimo();
        } else if (carType.equals(CarType.HATCH_BAG)) {
            return new MercedesHatchBag();
        } else return null;
    }

}
