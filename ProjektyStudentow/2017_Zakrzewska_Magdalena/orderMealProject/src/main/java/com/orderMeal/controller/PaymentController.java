package com.orderMeal.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurerAdapter;

import java.time.YearMonth;

import javax.servlet.http.HttpServletRequest;
import javax.validation.Valid;

import com.orderMeal.dao.OrderDao;
import com.orderMeal.dao.OrderDaoInterface;
import com.orderMeal.enums.PaymentType;
import com.orderMeal.model.Delivery;
import com.orderMeal.model.OrderDB;
import com.orderMeal.service.CashStrategy;
import com.orderMeal.service.ContextStrategy;
import com.orderMeal.service.CreditCardStrategy;
import com.orderMeal.service.Information;
import com.orderMeal.service.PaypalStrategy;
import com.orderMeal.service.RestaurantOliwaObserver;
import com.orderMeal.service.RestaurantWrzeszczObserver;

@SuppressWarnings("ALL")
@Controller
public class PaymentController extends WebMvcConfigurerAdapter {

    private ContextStrategy contextStrategy = null;
    private Delivery delivery;

    @Autowired
    private OrderDaoInterface orderDao;
    @Autowired
    private Information information;
    @Autowired
    private RestaurantWrzeszczObserver restaurantWrzeszczObserver;
    @Autowired
    private RestaurantOliwaObserver restaurantOliwaObserver;


    @GetMapping("/payment")
    public String paymentMenu(Delivery delivery) {
        return "payment";
    }

    @PostMapping("/payment")
    public String paymentChoose(@Valid Delivery delivery, BindingResult bindingResult, HttpServletRequest request) {
        String payment = request.getParameter("payment");

        if (bindingResult.hasErrors()) {
            return "payment";
        }

        this.delivery = delivery;

        switch (PaymentType.valueOf(payment)){
            case CREDIT_CARD:
                contextStrategy = new ContextStrategy(
                        new CreditCardStrategy()
                                .setCVV(request.getParameter("cvv"))
                                .setCreditCardNumber(request.getParameter("credit-card-number"))
                                .setExpiryDate(YearMonth.parse(request.getParameter("expiry-date-month")))
                    );
                break;
            case PAYPAL:
                contextStrategy = new ContextStrategy(
                        new PaypalStrategy()
                                .setEmail(request.getParameter("email"))
                                .setPassword(request.getParameter("password"))
                );
                break;
            case CASH:
                contextStrategy = new ContextStrategy(new CashStrategy());
                break;
        }

        return "redirect:pay";
    }

    @GetMapping("/pay")
    public String pay(Model model) {
        double cost = orderDao.getAllItems().stream().map(OrderDB::getPrise).reduce(0.0, Double::sum);

        model.addAttribute("name", delivery.getName());
        model.addAttribute("lastName", delivery.getLastName());
        model.addAttribute("paymentInfo", contextStrategy.executeStrategy(cost));

        information.setData(delivery, orderDao);

        return "pay";
    }
}
