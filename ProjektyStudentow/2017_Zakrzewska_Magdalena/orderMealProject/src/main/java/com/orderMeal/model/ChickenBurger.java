package com.orderMeal.model;

public class ChickenBurger extends Burger {

    @Override
    public String name() {
        return "Chicken Burger";
    }

    @Override
    public double price() {
        return 17.5f;
    }
}
