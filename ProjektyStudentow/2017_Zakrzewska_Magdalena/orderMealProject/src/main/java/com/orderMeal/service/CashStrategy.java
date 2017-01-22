package com.orderMeal.service;

public class CashStrategy implements PaymentStrategyInterface {

    @Override
    public String payment(double cost) {
        return "You will pay "+ cost + "zlotys by cash to delivery man.";
    }
}
