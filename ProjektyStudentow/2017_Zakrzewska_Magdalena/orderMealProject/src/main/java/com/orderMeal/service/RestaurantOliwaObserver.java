package com.orderMeal.service;

import org.springframework.stereotype.Component;

@Component
public class RestaurantOliwaObserver extends Observer {

    public RestaurantOliwaObserver(Information information){
        this.information = information;
        this.information.attach(this);
    }

    @Override
    public void update() {
        System.out.println(
                "Oliwa restaurant noticed - delivery for : "
                        + information.getDelivery().toString()
                        + " for "
                        + information.getOrder().getAllItems().toString()
        );
    }
}
