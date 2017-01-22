package com.orderMeal.model;

public abstract class Drink implements ItemInterface {

    @Override
    public PackingInterface packing() {
        return new Bottle();
    }

}
