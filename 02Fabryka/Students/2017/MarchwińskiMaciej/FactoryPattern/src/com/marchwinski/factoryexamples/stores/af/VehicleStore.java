package com.marchwinski.factoryexamples.stores.af;

import com.marchwinski.factoryexamples.vehicles.Vehicle;
import com.marchwinski.factoryexamples.vehicles.VehicleType;

public abstract class VehicleStore {
    public abstract Vehicle createVehicle(VehicleType vehicleType);

    public Vehicle orderVehicle(VehicleType type) {
        Vehicle vehicle = createVehicle(type);
        System.out.println("--- Making a " + vehicle.toString() + " ---");
        return vehicle;
    }
}
