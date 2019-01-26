package fabricMethodsFactories;

import cars.Car;
import utils.CarType;

public abstract class CarFactory {

    abstract Car createCar(CarType carType);

    public void orderCar(CarType carType){
        Car car = createCar(carType);
        car.createAllPartsOfTheCar();
        car.checkCar();
        car.cleanCar();
        car.sendCarToCLient();
    }

}
