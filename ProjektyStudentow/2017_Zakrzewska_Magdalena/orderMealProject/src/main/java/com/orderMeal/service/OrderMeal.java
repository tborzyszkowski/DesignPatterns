package com.orderMeal.service;

import com.orderMeal.model.ItemInterface;
import java.util.ArrayList;
import java.util.List;

public class OrderMeal {
    private List<ItemInterface> items = new ArrayList<>();

    public void addItem(ItemInterface item){
        items.add(item);
    }

    public List<ItemInterface> getItems(){
        return items;
    }

    public double getCost(){
        return items.stream().map(ItemInterface::price).reduce(0.0, Double::sum);
    }

    public String showItems(){
        String showitems = "";

        for (ItemInterface item : items) {
            showitems+="Item : " + item.name()+", Packing : " + item.packing().pack()+", Price : " + item.price() + " || ";

        }
        return showitems;
    }
}
