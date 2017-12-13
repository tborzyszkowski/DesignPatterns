package com.marchwinski.factoryexamples;

import com.marchwinski.factoryexamples.stores.af.VWVehicleStore;
import com.marchwinski.factoryexamples.stores.af.VehicleStore;
import com.marchwinski.factoryexamples.stores.af.VolvoVehicleStore;
import com.marchwinski.factoryexamples.vehicles.VehicleType;

public class Main {
    public static void main(String[] args) {
        // Simple Factory
/*        VolvoVehicleFactory factory = VolvoVehicleFactory.getInstance();
        factory.make(VehicleType.CAR);
        factory.make(VehicleType.BIKE);
        factory.make(VehicleType.ELECTRIC_WHEELCHAIR);*/

        //Factory method
/*        VehicleMethodFactory.getVehicle(VehicleType.CAR);
        VehicleMethodFactory.getVehicle(VehicleType.BIKE);
        VehicleMethodFactory.getVehicle(VehicleType.ELECTRIC_WHEELCHAIR);*/

VehicleStore volvoStore = new VolvoVehicleStore();
        volvoStore.createVehicle(VehicleType.CAR);
        volvoStore.createVehicle(VehicleType.BIKE);
        volvoStore.createVehicle(VehicleType.ELECTRIC_WHEELCHAIR);

        VehicleStore vwStore = new VWVehicleStore();
        vwStore.createVehicle(VehicleType.CAR);
        vwStore.createVehicle(VehicleType.BIKE);
        vwStore.createVehicle(VehicleType.ELECTRIC_WHEELCHAIR);


    }
}
