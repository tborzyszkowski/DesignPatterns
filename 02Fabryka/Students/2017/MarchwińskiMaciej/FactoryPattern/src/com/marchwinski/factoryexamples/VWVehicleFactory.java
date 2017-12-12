package com.marchwinski.factoryexamples;

import com.marchwinski.factoryexamples.vehicles.*;

public class VWVehicleFactory {
    private static VWVehicleFactory ourInstance = new VWVehicleFactory();

    public static VWVehicleFactory getInstance() {
        return ourInstance;
    }

    private VWVehicleFactory() {
    }

    public Vehicle make(VehicleType type) {
        switch (type) {
            case BIKE: {
                return new VWBike();
            }
            case CAR: {
                return new VWCar();
            }
            case ELECTRIC_WHEELCHAIR: {
                return new VWElectricWheelchair();
            }
            default: {
                System.out.println("It shouldn't happen.");
                return null;
            }

        }

    }
}
