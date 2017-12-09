package com.marchwinski.factoryexamples.stores.af;

import com.marchwinski.factoryexamples.VWVehicleFactory;
import com.marchwinski.factoryexamples.vehicles.Vehicle;
import com.marchwinski.factoryexamples.vehicles.VehicleType;

public class VWVehicleStore extends VehicleStore {
    @Override
    public Vehicle createVehicle(VehicleType vehicleType) {
        Vehicle vehicle = null;
        VWVehicleFactory vwVehicleFactory =
                VWVehicleFactory.getInstance();

        switch (vehicleType) {
            case BIKE: {
                return vwVehicleFactory.make(vehicleType);
            }
            case CAR: {
                return vwVehicleFactory.make(vehicleType);
            }
            case ELECTRIC_WHEELCHAIR: {
                return vwVehicleFactory.make(vehicleType);
            }
            default: {
                System.out.println("It shouldn't happen.");
                return null;
            }
        }    }
}
