package FactoryMethod;

import Products.Vehicle;

public abstract class VehicleStore {
    abstract Vehicle createVehicle(String item);

    public Vehicle Build(String name) {
        Vehicle vehicle = createVehicle(name);


//        vehicle.build();

        return vehicle;
    }
}
