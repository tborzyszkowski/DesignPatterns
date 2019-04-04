package FactoryMethod;

import Products.Motorcycles.CBR;
import Products.Motorcycles.HP4;
import Products.Motorcycles.VFR;
import Products.Vehicle;

public class MotorStore extends VehicleStore {
    private static MotorStore instance;

    private MotorStore() {}

    public static MotorStore getInstance() {
        if(instance == null)
            instance = new MotorStore();
        return instance;
    }

    @Override
    Vehicle createVehicle(String model) {
        model = model.toLowerCase();

        if(model.equals("cbr")){
            return new CBR();
        } else if(model.equals("hp4")) {
            return new HP4();
        } else if(model.equals("vfr")) {
            return new VFR();
        } else return null;
    }
}
