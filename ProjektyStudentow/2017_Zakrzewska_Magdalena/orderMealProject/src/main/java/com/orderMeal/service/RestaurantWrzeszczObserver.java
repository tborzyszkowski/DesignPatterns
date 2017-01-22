package com.orderMeal.service;

import org.springframework.stereotype.Component;

@Component
public class RestaurantWrzeszczObserver extends Observer {

    public RestaurantWrzeszczObserver(Information information){
        this.information = information;
        this.information.attach(this);
    }

    @Override
    public void update() {
        System.out.println(
                "Wrzeszcz restaurant noticed - delivery for : "
                + information.getDelivery().toString()
                + " for "
                + information.getOrder().getAllItems().toString()
        );
    }
}
