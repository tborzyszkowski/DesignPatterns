package com.orderMeal.service;

public class ContextStrategy {
    private PaymentStrategyInterface paymentStrategyInterface;

    public ContextStrategy(PaymentStrategyInterface paymentStrategyInterface) {
        this.paymentStrategyInterface = paymentStrategyInterface;
    }

    public String executeStrategy(double cost) {
        return paymentStrategyInterface.payment(cost);
    }
}
