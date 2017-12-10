package com.marchwinski.builder.bike_parts;

public class Wheels {

    private String name;

    public Wheels(String name) {
        this.name = name;
    }

    @Override
    public String toString() {
        return "Wheels{" +
                "name='" + name + '\'' +
                '}';
    }
}
