package SimpleFactory;

import Products.Bicycle;
import Products.Car;
import Products.Motorcycle;

public class VehicleStore {
    private SimpleVehicleFactory _factory;

    public VehicleStore() {
        this._factory = SimpleVehicleFactory.getInstance();
    }

    public Car OrderCar(String model){
        Car car = _factory.CreateCar(model);
        if(car == null)
            return null;

//        car.build();
//        car.fuel();
//        car.drive();

        return car;
    }

    public Motorcycle OrderMotorcycle(String model) {
        Motorcycle motor = _factory.CreateMotor(model);
        if(motor == null)
            return null;

        motor.build();
        motor.fuel();
        motor.drive();
        motor.wheelie();
        return motor;
    }

    public Bicycle OrderBike(String model) {
        Bicycle bike = _factory.CreateBike(model);
        if(bike == null)
            return null;

        bike.build();
        bike.drive();
        bike.repair();
        return bike;
    }
}
