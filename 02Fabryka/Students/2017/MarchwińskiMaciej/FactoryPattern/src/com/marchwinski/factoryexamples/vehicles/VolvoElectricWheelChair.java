package com.marchwinski.factoryexamples.vehicles;

import com.marchwinski.factoryexamples.parts.VolvoWheel;
import com.marchwinski.factoryexamples.parts.VolvoWheelchairSeat;

public class VolvoElectricWheelChair extends Vehicle{
    public VolvoElectricWheelChair(){
        System.out.println("---- Starting of building electric wheelchair. ----");
        System.out.println(new VolvoWheelchairSeat().getDescription());
        System.out.println(new VolvoWheel().getDescription());
        System.out.println(new VolvoWheel().getDescription());
        System.out.println("Wheelchair ready !");
    }
}
