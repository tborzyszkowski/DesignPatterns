package com.orderMeal.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;

import java.util.ArrayList;

import java.util.List;
import java.util.stream.Collectors;
import javax.servlet.http.HttpServletRequest;

import com.orderMeal.builder.OrderBuilder;
import com.orderMeal.dao.OrderDao;
import com.orderMeal.dao.OrderDaoInterface;
import com.orderMeal.mapper.OrderMapper;
import com.orderMeal.service.OrderMeal;
import com.orderMeal.enums.BurgerType;
import com.orderMeal.enums.DrinkType;

@Controller
public class OrderMealController {

    private final List<OrderMeal> orderMeals = new ArrayList<>();

    @Autowired
    private OrderDaoInterface orderDao = new OrderDao();

    @GetMapping("/order")
    public String orderMenu() {
        return "order";
    }

    @GetMapping("/meals")
    public String allOrders(Model model) {
        Double costs = orderMeals.stream().map(OrderMeal::getCost).reduce(0.0, Double::sum);
        String items = orderMeals.stream().map(OrderMeal::showItems).collect(Collectors.joining(" "));

        model.addAttribute("costs", costs);
        model.addAttribute("items", items);

        return "meals";
    }


    @PostMapping("/order")
    public String orderMeal(HttpServletRequest request) {
        OrderBuilder mealBuilder = new OrderBuilder();
        String burger = request.getParameter("burger");
        String drink = request.getParameter("drink");

        if (burger.equals(BurgerType.BEEF.getName())) {
            if (drink.equals(DrinkType.COKE.getName())) {
                orderMeals.add(mealBuilder.orderBeefBurgerWithCoke());
            } else {
                orderMeals.add(mealBuilder.orderBeefBurgerWithPepsi());
            }
        } else if (burger.equals(BurgerType.PORK.getName())) {
            if (drink.equals(DrinkType.COKE.getName())) {
                orderMeals.add(mealBuilder.orderPorkBurgerWithCoke());
            } else {
                orderMeals.add(mealBuilder.orderPorkBurgerWithPepsi());
            }
        } else if (burger.equals(BurgerType.CHICKEN.getName())) {
            if (drink.equals(DrinkType.COKE.getName())) {
                orderMeals.add(mealBuilder.orderChickenBurgerWithCoke());
            } else {
                orderMeals.add(mealBuilder.orderChickenBurgerWithPepsi());
            }
        }

        return "redirect:meals";
    }

    @PostMapping("/meals")
    public String finishOrder() {
        int[] idx = { 0 };
        orderMeals.stream().forEachOrdered(i -> i.getItems().stream().forEachOrdered(item -> orderDao.addItem(OrderMapper.map(idx[0]++,item))));
        return "redirect:payment";
    }
}
