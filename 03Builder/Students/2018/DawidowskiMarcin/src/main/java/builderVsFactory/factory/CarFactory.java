package builderVsFactory.factory;

import builderVsFactory.Car;

public class CarFactory {
    public static Car getCar(CarAbstractFactory factory){
        return factory.showCar();
    }
}
