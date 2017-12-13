package com.marchwinski.factoryexamples.vehicles;

import com.marchwinski.factoryexamples.parts.VWCarFrame;
import com.marchwinski.factoryexamples.parts.VWCarSeat;

public class VWCar extends Vehicle {
    public VWCar() {
        System.out.println("---- Starting of building car. ----");
        System.out.println(new VWCarSeat().getDescription());
        System.out.println(new VWCarSeat().getDescription());
        System.out.println(new VWCarSeat().getDescription());
        System.out.println(new VWCarSeat().getDescription());
        System.out.println(new VWCarFrame().getDescription());
        System.out.println("VW car is ready! wzioooom...");
    }
}
