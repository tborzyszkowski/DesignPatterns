package com.marchwinski.factoryexamples.vehicles;

import com.marchwinski.factoryexamples.parts.VolvoCarFrame;
import com.marchwinski.factoryexamples.parts.VolvoCarSeat;

public class VolvoCar extends Vehicle {
    public VolvoCar(){
        System.out.println("---- Starting of building car. ----");
        System.out.println(new VolvoCarSeat().getDescription());
        System.out.println(new VolvoCarSeat().getDescription());
        System.out.println(new VolvoCarSeat().getDescription());
        System.out.println(new VolvoCarSeat().getDescription());
        System.out.println(new VolvoCarFrame().getDescription());
        System.out.println("VolvoCar is ready! wzioooom...");
    }
}
