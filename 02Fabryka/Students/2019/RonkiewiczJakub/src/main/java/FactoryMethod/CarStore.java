package FactoryMethod;

import Products.Cars.Carrera;
import Products.Cars.Civic;
import Products.Cars.M240;
import Products.Cars.Micra;
import Products.Vehicle;

public class CarStore extends VehicleStore {
    private static CarStore instance;

    private CarStore() {}

    public static CarStore getInstance() {
        if(instance == null)
            instance = new CarStore();
        return instance;
    }

    @Override
    Vehicle createVehicle(String model) {
        model = model.toLowerCase();

        if(model.equals("carrera")){
            return new Carrera();
        } else if(model.equals("civic")) {
            return new Civic();
        } else if(model.equals("m240")) {
            return new M240();
        } else if(model.equals("micra")){
            return new Micra();
        } else return null;
    }
}
