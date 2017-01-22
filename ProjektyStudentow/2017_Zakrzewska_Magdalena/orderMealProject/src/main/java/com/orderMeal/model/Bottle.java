package com.orderMeal.model;

public class Bottle implements PackingInterface {

    @Override
    public String pack() {
        return "Bottle";
    }
}
