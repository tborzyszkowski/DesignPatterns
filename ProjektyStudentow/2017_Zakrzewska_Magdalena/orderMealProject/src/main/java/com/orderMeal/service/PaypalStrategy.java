package com.orderMeal.service;

public class PaypalStrategy implements PaymentStrategyInterface {
    private String email;
    private String password;

    public PaypalStrategy setPassword(String password) {
        this.password = password;
        return this;
    }

    public PaypalStrategy setEmail(String email) {
        this.email = email;
        return this;
    }

    @Override
    public String payment(double cost) {
        return "We send the request to paypal for "+ cost + "zlotys.";
    }
}
