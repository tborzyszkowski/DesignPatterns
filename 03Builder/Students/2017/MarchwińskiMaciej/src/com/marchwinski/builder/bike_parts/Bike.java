package com.marchwinski.builder.bike_parts;

public class Bike {

    private Wheels wheels;
    private Frame frame;
    private SteeringWheel steeringWheel;

    @Override
    public String toString() {
        return "Bike{" +
                "wheels=" + wheels +
                ", frame=" + frame +
                ", steeringWheel=" + steeringWheel +
                '}';
    }

    public Wheels getWheels() {
        return wheels;
    }

    public void setWheels(Wheels wheels) {
        this.wheels = wheels;
    }

    public Frame getFrame() {
        return frame;
    }

    public void setFrame(Frame frame) {
        this.frame = frame;
    }

    public SteeringWheel getSteeringWheel() {
        return steeringWheel;
    }

    public void setSteeringWheel(SteeringWheel steeringWheel) {
        this.steeringWheel = steeringWheel;
    }
}
