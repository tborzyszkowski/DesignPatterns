package model;

import java.util.ArrayList;
import java.util.List;

public abstract class Bike {
    String brand;
    BikeType type;
    String wheels;
    String frame;
    boolean engine;
    List<String> parts = new ArrayList<>();

    public String getBrand() {
        return brand;
    }

    public void setBrand(String brand) {
        this.brand = brand;
    }

    public BikeType getType() {
        return type;
    }

    public void setType(BikeType type) {
        this.type = type;
    }

    public String getWheels() {
        return wheels;
    }

    public void setWheels(String wheels) {
        this.wheels = wheels;
    }

    public String getFrame() {
        return frame;
    }

    public void setFrame(String frame) {
        this.frame = frame;
    }

    public boolean isEngine() {
        return engine;
    }

    public void setEngine(boolean engine) {
        this.engine = engine;
    }

    public List<String> getParts() {
        return parts;
    }

    public void setParts(List<String> parts) {
        this.parts = parts;
    }

    public void prepareParts() {
        System.out.println("Preparing parts for " + type);
    }

    public abstract Bike createBike();

    @Override
    public String toString() {
        return "Bike{" +
                "brand='" + brand + '\'' +
                ", type=" + type +
                ", wheels='" + wheels + '\'' +
                ", frame='" + frame + '\'' +
                ", engine=" + engine +
                ", parts=" + parts +
                '}';
    }
}
