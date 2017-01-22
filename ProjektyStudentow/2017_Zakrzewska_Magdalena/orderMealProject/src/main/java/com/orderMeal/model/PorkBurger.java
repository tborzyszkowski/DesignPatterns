package com.orderMeal.model;

public class PorkBurger extends Burger {

    @Override
    public String name() {
        return "Pork Burger";
    }

    @Override
    public double price() {
        return 13.1f;
    }
}
