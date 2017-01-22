package com.orderMeal.dao;

import java.util.List;

import com.orderMeal.model.OrderDB;

public interface OrderDaoInterface {
    public List<OrderDB> getAllItems();
    public OrderDB getItem(int id);
    public void addItem(OrderDB item);
    public void updateItem(OrderDB item);
    public void deleteItem(OrderDB item);
}
