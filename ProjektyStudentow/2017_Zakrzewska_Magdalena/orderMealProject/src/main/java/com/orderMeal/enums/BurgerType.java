package com.orderMeal.enums;

public enum BurgerType {
    PORK("pork"), CHICKEN("chicken"), BEEF("beef");

    private String name;

    BurgerType(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }
}
