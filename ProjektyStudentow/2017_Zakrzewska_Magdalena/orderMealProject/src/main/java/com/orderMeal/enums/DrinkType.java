package com.orderMeal.enums;

public enum DrinkType {
    COKE("coke"), PEPSI("pepsi");

    private String name;

    DrinkType(String name) {
        this.name = name;
    }

    public String getName()
    {
        return name;
    }
}
