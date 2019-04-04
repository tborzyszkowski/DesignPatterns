package SimpleFactory;

import Products.Bicycle;
import Products.Bicycles.BikeRS;
import Products.Bicycles.Endurace;
import Products.Bicycles.SilverBullet;
import Products.Car;
import Products.Cars.Carrera;
import Products.Cars.Civic;
import Products.Cars.M240;
import Products.Cars.Micra;
import Products.Motorcycle;
import Products.Motorcycles.CBR;
import Products.Motorcycles.HP4;
import Products.Motorcycles.VFR;

public class SimpleVehicleFactory {
    private static SimpleVehicleFactory instance;

    private SimpleVehicleFactory() {}

    public static SimpleVehicleFactory getInstance() {
        if (instance == null)
            instance = new SimpleVehicleFactory();
        return instance;
    }

    //

    public Car CreateCar(String model) {
        model = model.toLowerCase();
        Car car = null;

        if(model.equals("carrera")){
            car = new Carrera();
        } else if(model.equals("civic")) {
            car = new Civic();
        } else if(model.equals("m240")) {
            car = new M240();
        } else if(model.equals("micra")){
            car = new Micra();
        }

        return car;
    }

    public Motorcycle CreateMotor(String model) {
        model = model.toLowerCase();
        Motorcycle motor = null;

        if(model.equals("cbr")){
            motor = new CBR();
        } else if(model.equals("hp4")){
            motor = new HP4();
        } else if(model.equals("vfr")){
            motor = new VFR();
        }

        return motor;
    }

    public Bicycle CreateBike(String model) {
        model = model.toLowerCase();
        Bicycle bike = null;

        if(model.equals("bikers")) {
            bike = new BikeRS();
        } else if(model.equals("endurace")){
            bike = new Endurace();
        } else if(model.equals("silverbullet")){
            bike = new SilverBullet();
        }

        return bike;
    }

}
