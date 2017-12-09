package pl.mhallman.java.factoryRegPattern.model;

import pl.mhallman.java.factoryRegPattern.factory.CookieFactory;

import java.util.ArrayList;

import static java.util.Arrays.asList;

public class CrumbleCookie extends Cookie {

    static {
        CookieFactory.INSTANCE.registerCookie("CrumbleCookie", new CrumbleCookie());
    }

    @Override
    public CrumbleCookie createCookie() {
        CrumbleCookie crumbleCookie = new CrumbleCookie();
        crumbleCookie.name = "Fantastic Cookie with Caramel Crumble";
        crumbleCookie.flour = "Rice Flour";
        crumbleCookie.milk = "Low-fat Milk";
        crumbleCookie.topping = "Double Caramel";
        crumbleCookie.additives = new ArrayList<String>(asList("Caramel", "Milk chocolate"));
        return crumbleCookie;
    }
}
