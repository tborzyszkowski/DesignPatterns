package com.orderMeal.mapper;

import com.orderMeal.model.ItemInterface;
import com.orderMeal.model.OrderDB;

public class OrderMapper {
    public static OrderDB map(int id, ItemInterface item) {
        return new OrderDB()
                .setId(id)
                .setName(item.name())
                .setPrise(item.price())
                .setWrapping(item.packing().pack());
    }
}
