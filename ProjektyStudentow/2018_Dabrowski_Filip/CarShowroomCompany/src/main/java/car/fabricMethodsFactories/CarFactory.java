package car.fabricMethodsFactories;

import car.cars.Car;
import car.utils.CarType;

public abstract class CarFactory {

    abstract Car createCar(CarType carType);

    public Car orderCar(CarType carType){
        Car car = createCar(carType);
        car.createAllPartsOfTheCar();
        car.checkCar();
        car.cleanCar();
        car.sendCarToCLient();
        return car;
    }

}
