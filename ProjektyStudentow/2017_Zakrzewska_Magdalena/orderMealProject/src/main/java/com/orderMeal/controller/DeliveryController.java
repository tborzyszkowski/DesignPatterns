package com.orderMeal.controller;

import com.orderMeal.dao.OrderDao;
import com.orderMeal.dao.OrderDaoInterface;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;

import java.util.ArrayList;

@Controller
public class DeliveryController {

    @Autowired
    private OrderDaoInterface orderDao = new OrderDao();

    @GetMapping("/delivery")
    public String delivery(Model model) {
        ArrayList<String> lists = new ArrayList<>();
        String listValue = "List A";
        lists.add(listValue);

        model.addAttribute("lists", lists);

        return "delivery";
    }
}
