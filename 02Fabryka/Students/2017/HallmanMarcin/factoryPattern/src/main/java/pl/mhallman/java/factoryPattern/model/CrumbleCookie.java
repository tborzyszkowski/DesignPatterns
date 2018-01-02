package pl.mhallman.java.factoryPattern.model;

import java.util.ArrayList;

import static java.util.Arrays.asList;

public class CrumbleCookie extends Cookie {
    public CrumbleCookie() {
        this.name = "Fantastic Cookie with Caramel Crumble";
        this.flour = "Rice Flour";
        this.milk = "Low-fat Milk";
        this.topping = "Double Caramel";
        this.additives = new ArrayList<String>(asList("Caramel", "Milk chocolate"));
    }
}
