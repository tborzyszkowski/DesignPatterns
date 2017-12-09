package com.marchwinski.builder;

import com.marchwinski.builder.bike_parts.Bike;
import com.marchwinski.builder.bikes.SlowBike;

public class BikeClient {

    public static void main(String[] args) {
        IBikeBuilder bikeBuilder = new SlowBike();
        BikeDirector bikeDirector = new BikeDirector(bikeBuilder);
        bikeDirector.makeBike();
        Bike bike = bikeDirector.getBike();
        System.out.print(bike);
    }
}
