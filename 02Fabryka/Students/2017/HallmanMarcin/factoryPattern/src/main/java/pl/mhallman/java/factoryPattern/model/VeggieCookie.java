package pl.mhallman.java.factoryPattern.model;

import java.util.ArrayList;

import static java.util.Arrays.asList;

public class VeggieCookie extends Cookie {
    public VeggieCookie() {
        this.name = "Healthy Veggie Cookie";
        this.flour = "Organic Flour";
        this.milk = "Organic Milk";
        this.topping = "Honey";
        this.additives = new ArrayList<String>(asList("Corn flakes", "Cranberry"));
    }
}
