package com.marchwinski.builder.bike_parts;

public class SteeringWheel {

    private String name;

    public SteeringWheel(String name) {
        this.name = name;
    }

    @Override
    public String toString() {
        return "SteeringWheel{" +
                "name='" + name + '\'' +
                '}';
    }
}
