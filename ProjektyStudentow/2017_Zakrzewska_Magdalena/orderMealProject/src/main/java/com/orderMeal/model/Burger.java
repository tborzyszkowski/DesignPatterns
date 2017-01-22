package com.orderMeal.model;

public abstract class Burger implements ItemInterface {

    @Override
    public PackingInterface packing() {
        return new Wrapper();
    }
}
