package com.marchwinski.factoryexamples.vehicles;

import com.marchwinski.factoryexamples.parts.VWWheel;
import com.marchwinski.factoryexamples.parts.VWWheelchairSeat;

public class VWElectricWheelchair extends Vehicle {
    public VWElectricWheelchair() {
        System.out.println("---- Starting of building electric wheelchair. ----");
        System.out.println(new VWWheelchairSeat().getDescription());
        System.out.println(new VWWheel().getDescription());
        System.out.println(new VWWheel().getDescription());
        System.out.println("VW Wheelchair ready !");
    }
}
