package com.orderMeal.controller;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

import com.orderMeal.dao.OrderDao;
import com.orderMeal.dao.OrderDaoInterface;
import com.orderMeal.service.Information;
import com.orderMeal.service.RestaurantOliwaObserver;
import com.orderMeal.service.RestaurantWrzeszczObserver;

import org.springframework.boot.web.support.SpringBootServletInitializer;
import org.springframework.context.annotation.ComponentScan;

@SpringBootApplication
@ComponentScan("com.orderMeal")
public class Application extends SpringBootServletInitializer{

    public static void main(String[] args) {

        OrderDaoInterface orderDao = new OrderDao();
        Information information = new Information();

        RestaurantWrzeszczObserver restaurantWrzeszczObserver = new RestaurantWrzeszczObserver(information);
        RestaurantOliwaObserver restaurantOliwaObserver = new RestaurantOliwaObserver(information);

        SpringApplication.run(Application.class, args);
    }
}
