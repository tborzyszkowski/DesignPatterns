package com.orderMeal.model;

public class Coke extends Drink {

    @Override
    public String name() {
        return "Coke";
    }

    @Override
    public double price() {
        return 5f;
    }
}
