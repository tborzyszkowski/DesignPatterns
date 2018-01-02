package com.marchwinski.factoryexamples.vehicles;

import com.marchwinski.factoryexamples.parts.VWBikeSeat;
import com.marchwinski.factoryexamples.parts.VWWheel;

public class VWBike extends Vehicle {
    public VWBike() {
        System.out.println("---- Starting of building bike. ----");
        System.out.println(new VWWheel().getDescription());
        System.out.println(new VWWheel().getDescription());
        System.out.println(new VWBikeSeat().getDescription());
        System.out.println("VW bike ready ! brum brum !");
    }
}
