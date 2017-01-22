package com.orderMeal.builder;

import com.orderMeal.model.BeefBurger;
import com.orderMeal.model.Burger;
import com.orderMeal.model.ChickenBurger;
import com.orderMeal.model.Coke;
import com.orderMeal.model.Drink;
import com.orderMeal.model.Pepsi;
import com.orderMeal.model.PorkBurger;
import com.orderMeal.service.OrderMeal;

public class OrderBuilder {

    private OrderMeal orderMeal(Burger burger, Drink drink) {
        OrderMeal orderMeal = new OrderMeal();
        orderMeal.addItem(burger);
        orderMeal.addItem(drink);

        return orderMeal;
    }

    public OrderMeal orderBeefBurgerWithCoke() {
        return orderMeal(new BeefBurger(), new Coke());
    }

    public OrderMeal orderPorkBurgerWithCoke() {
        return orderMeal(new PorkBurger(), new Coke());
    }

    public OrderMeal orderChickenBurgerWithCoke()
    {
        return orderMeal(new ChickenBurger(), new Coke());
    }

    public OrderMeal orderBeefBurgerWithPepsi()
    {
        return orderMeal(new BeefBurger(), new Pepsi());
    }

    public OrderMeal orderPorkBurgerWithPepsi()
    {
        return orderMeal(new PorkBurger(), new Pepsi());
    }

    public OrderMeal orderChickenBurgerWithPepsi()
    {
        return orderMeal(new ChickenBurger(), new Pepsi());
    }
}
