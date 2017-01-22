package com.orderMeal.model;

public class Pepsi extends Drink {

    @Override
    public String name() {
        return "Pepsi";
    }

    @Override
    public double price() {
        return 5.5f;
    }
}
