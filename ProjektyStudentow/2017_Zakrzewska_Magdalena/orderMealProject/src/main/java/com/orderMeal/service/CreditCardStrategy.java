package com.orderMeal.service;

import java.time.YearMonth;

public class CreditCardStrategy implements PaymentStrategyInterface{
    private String creditCardNumber;
    private YearMonth expiryDate;
    private String CVV;

    @Override
    public String payment(double cost) {
        return "we have took from " + creditCardNumber + " card number " + cost + " zlotys.";
    }


    public CreditCardStrategy setCVV(String CVV) {
        this.CVV = CVV;
        return this;
    }

    public CreditCardStrategy setCreditCardNumber(String creditCardNumber) {
        this.creditCardNumber = creditCardNumber;
        return this;
    }

    public CreditCardStrategy setExpiryDate(YearMonth expiryDate) {
        this.expiryDate = expiryDate;
        return this;
    }
}
