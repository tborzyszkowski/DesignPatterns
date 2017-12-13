package com.marchwinski.factoryexamples.stores.af;

import com.marchwinski.factoryexamples.vehicles.Vehicle;
import com.marchwinski.factoryexamples.vehicles.VehicleType;
import com.marchwinski.factoryexamples.VolvoVehicleFactory;

public class VolvoVehicleStore extends VehicleStore {

    @Override
    public Vehicle createVehicle(VehicleType vehicleType) {
        Vehicle vehicle = null;
        VolvoVehicleFactory volvoVehicleFactory =
                VolvoVehicleFactory.getInstance();

        switch (vehicleType) {
            case BIKE: {
                return volvoVehicleFactory.make(vehicleType);
            }
            case CAR: {
                return volvoVehicleFactory.make(vehicleType);
            }
            case ELECTRIC_WHEELCHAIR: {
                return volvoVehicleFactory.make(vehicleType);
            }
            default: {
                System.out.println("It shouldn't happen.");
                return null;
            }
        }
    }
}
