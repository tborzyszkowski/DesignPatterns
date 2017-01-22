package com.orderMeal.service;

import com.orderMeal.dao.OrderDaoInterface;
import com.orderMeal.model.Delivery;

import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

@Component
public class Information {

    private List<Observer> observers = new ArrayList<>();
    private Delivery delivery;
    private OrderDaoInterface orderDao;

    public Delivery getDelivery() {
        return delivery;
    }
    public OrderDaoInterface getOrder() {
        return orderDao;
    }

    public void setData(Delivery delivery, OrderDaoInterface orderDao) {
        this.delivery = delivery;
        this.orderDao = orderDao;
        notifyAllObservers();
    }

    public void attach(Observer observer){
        observers.add(observer);
    }

    public void notifyAllObservers(){
        for (Observer observer : observers) {
            observer.update();
        }
    }
}
