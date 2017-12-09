package pl.mhallman.java.factoryPattern.model;

import java.util.ArrayList;

import static java.util.Arrays.asList;

public class ChocoCookie extends Cookie {

    public ChocoCookie() {
        this.name = "Delicious Choco Cookie";
        this.flour = "Cake Flour";
        this.milk = "Whole Milk";
        this.topping = "Chocolate and Caramel";
        this.additives = new ArrayList<String>(asList("White chocolate", "Milk chocolate"));
    }
}
