package com.orderMeal.dao;

import com.orderMeal.model.OrderDB;

import org.springframework.context.annotation.Bean;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

@Component
public class OrderDao implements OrderDaoInterface {

    //working as DB
    static List<OrderDB> orderDao = new ArrayList<>();

    @Override
    public List<OrderDB> getAllItems() {
        return orderDao;
    }

    @Override
    public OrderDB getItem(int id) {
        return orderDao.get(id);
    }

    @Override
    public void addItem(OrderDB item) {
        orderDao.add(item);
    }

    @Override
    public void updateItem(OrderDB item) {
        orderDao.get(item.getId())
                .setName(item.getName())
                .setPrise(item.getPrise())
                .setWrapping(item.getWrapping());
    }

    @Override
    public void deleteItem(OrderDB item) {
        orderDao.remove(item);
    }
}
