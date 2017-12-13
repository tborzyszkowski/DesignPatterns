package com.marchwinski.factoryexamples;

import com.marchwinski.factoryexamples.vehicles.*;

public class VolvoVehicleFactory {
    private static VolvoVehicleFactory ourInstance = new VolvoVehicleFactory();

    public static VolvoVehicleFactory getInstance() {
        return ourInstance;
    }

    private VolvoVehicleFactory() {
    }

    public Vehicle make(VehicleType type) {
        switch (type) {
            case BIKE: {
                return new VolvoBike();
            }
            case CAR: {
                return new VolvoCar();
            }
            case ELECTRIC_WHEELCHAIR: {
                return new VolvoElectricWheelChair();
            }
            default: {
                System.out.println("It shouldn't happen.");
                return null;
            }

        }

    }
}
