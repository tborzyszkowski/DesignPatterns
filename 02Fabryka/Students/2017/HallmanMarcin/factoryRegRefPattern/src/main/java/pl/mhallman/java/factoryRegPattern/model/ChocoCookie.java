package pl.mhallman.java.factoryRegPattern.model;

import pl.mhallman.java.factoryRegPattern.factory.CookieFactory;

import java.util.ArrayList;

import static java.util.Arrays.asList;

public class ChocoCookie extends Cookie {

    static {
        CookieFactory.INSTANCE.registerCookie("ChocoCookie", new ChocoCookie());
    }

    @Override
    public ChocoCookie createCookie() {
        ChocoCookie chocoCookie = new ChocoCookie();
        chocoCookie.name = "Delicious Choco Cookie";
        chocoCookie.flour = "Cake Flour";
        chocoCookie.milk = "Whole Milk";
        chocoCookie.topping = "Chocolate and Caramel";
        chocoCookie.additives = new ArrayList<String>(asList("White chocolate", "Milk chocolate"));
        return chocoCookie;
    }
}
