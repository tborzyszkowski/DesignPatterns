package com.marchwinski.factoryexamples.vehicles;

import com.marchwinski.factoryexamples.parts.VolvoBikeSeat;
import com.marchwinski.factoryexamples.parts.VolvoWheel;

public class VolvoBike extends Vehicle {
    public VolvoBike() {
        System.out.println("---- Starting of building bike. ----");
        System.out.println(new VolvoWheel().getDescription());
        System.out.println(new VolvoWheel().getDescription());
        System.out.println(new VolvoBikeSeat().getDescription());
        System.out.println("VolvoBike ready ! brum brum !");
    }
}
