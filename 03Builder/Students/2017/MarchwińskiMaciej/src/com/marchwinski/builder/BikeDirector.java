package com.marchwinski.builder;

import com.marchwinski.builder.bike_parts.Bike;

public class BikeDirector {

    private IBikeBuilder bikeBuilder;

    public BikeDirector(IBikeBuilder bikeBuilder) {
        this.bikeBuilder = bikeBuilder;
    }

    public void makeBike() {
        bikeBuilder.buildFrame();
        bikeBuilder.buildSteergingWheel();
        bikeBuilder.buildWheels();
    }

    public Bike getBike() {
        return bikeBuilder.getBike();
    }
}
