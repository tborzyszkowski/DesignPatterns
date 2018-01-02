package com.marchwinski.builder.bike_parts;

public class Frame {
    private String name;

    public Frame(String name) {
        this.name = name;
    }

    @Override
    public String toString() {
        return "Frame{" +
                "name='" + name + '\'' +
                '}';
    }
}
