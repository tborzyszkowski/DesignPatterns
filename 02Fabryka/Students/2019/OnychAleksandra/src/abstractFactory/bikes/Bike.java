package abstractFactory.bikes;

import abstractFactory.parts.baskets.Basket;
import abstractFactory.parts.bells.Bell;
import abstractFactory.parts.lamps.Lamp;
import model.BikeType;

import java.util.ArrayList;
import java.util.List;

public abstract class Bike {
    String brand;
    BikeType type;
    String wheels;
    String frame;
    boolean engine;
    Bell bell;
    Lamp lamp;
    Basket basket;

    public void prepareParts() {
        System.out.println("Preparing parts for " + brand);
    }

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

    public Bell getBell() {
        return bell;
    }

    public void setBell(Bell bell) {
        this.bell = bell;
    }

    public Lamp getLamp() {
        return lamp;
    }

    public void setLamp(Lamp lamp) {
        this.lamp = lamp;
    }

    public Basket getBasket() {
        return basket;
    }

    public void setBasket(Basket basket) {
        this.basket = basket;
    }

    @Override
    public String toString() {
        return "Bike{" +
                "brand='" + brand + '\'' +
                ", type=" + type +
                ", wheels='" + wheels + '\'' +
                ", frame='" + frame + '\'' +
                ", engine=" + engine +
                ", bell=" + bell.getType() +
                ", lamp=" + lamp.getType() +
                ", basket=" + basket.getType() +
                '}';
    }
}
