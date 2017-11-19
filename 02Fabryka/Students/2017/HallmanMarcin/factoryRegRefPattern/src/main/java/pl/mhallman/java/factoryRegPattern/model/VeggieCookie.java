package pl.mhallman.java.factoryRegPattern.model;

import pl.mhallman.java.factoryRegPattern.factory.CookieFactory;

import java.util.ArrayList;

import static java.util.Arrays.asList;

public class VeggieCookie extends Cookie {

    static {
        CookieFactory.INSTANCE.registerCookie("VeggieCookie", new VeggieCookie());
    }

    @Override
    public VeggieCookie createCookie() {
        VeggieCookie veggieCookie = new VeggieCookie();
        veggieCookie.name = "Healthy Veggie Cookie";
        veggieCookie.flour = "Organic Flour";
        veggieCookie.milk = "Organic Milk";
        veggieCookie.topping = "Honey";
        veggieCookie.additives = new ArrayList<String>(asList("Corn flakes", "Cranberry"));
        return veggieCookie;
    }
}
