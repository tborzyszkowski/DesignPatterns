package com.orderMeal.model;

public class BeefBurger extends Burger {

    @Override
    public String name() {
        return "Beef Burger";
    }

    @Override
    public double price() {
        return 19.25f;
    }
}
