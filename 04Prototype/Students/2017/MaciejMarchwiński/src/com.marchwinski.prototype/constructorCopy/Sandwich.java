package com.marchwinski.prototype.constructorCopy;

import java.io.Serializable;

public class Sandwich implements Serializable {
    private Meat meat;
    private Cheese cheese;
    private Sauce sauce;

    public Sandwich(Sandwich otherSandwich){
        this.meat = new Meat(otherSandwich.meat);
        this.cheese = new Cheese(otherSandwich.cheese);
        this.sauce = new Sauce(otherSandwich.sauce);
    }

    public Sandwich(Meat meat, Cheese cheese, Sauce sauce){
        this.meat = meat;
        this.cheese = cheese;
        this.sauce = sauce;
    }


    public Meat getMeat() {
        return meat;
    }

    public Cheese getCheese() {
        return cheese;
    }

    public Sauce getSauce() {
        return sauce;
    }

    @Override
    public String toString() {
        return "Sandwich{" +
                "meat=" + meat +
                ", cheese=" + cheese.toComplexString() +
                ", sauce=" + sauce +
                '}';
    }
}
