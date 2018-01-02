package com.marchwinski.builder;

import com.marchwinski.builder.bike_parts.Bike;

public interface IBikeBuilder {
    void buildFrame();

    void buildWheels();

    void buildSteergingWheel();

    Bike getBike();
}


