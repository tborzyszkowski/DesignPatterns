package com.orderMeal.enums;

public enum PaymentType {
    CREDIT_CARD("creditCard"), PAYPAL("paypal"), CASH("cash");

    private String name;

    PaymentType(String name) {
        this.name = name;
    }

    public String getName()
    {
        return name;
    }
}
