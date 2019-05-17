package FactoryOverBuilder.AbstractFactory.Factories;

import FactoryOverBuilder.AbstractFactory.Products.Shoes;

public abstract class AbstractFactoryOrder {

    abstract Shoes createShoes(String sport, int size, String color);

    public Shoes orderShoes(String sport, int size, String color){
        Shoes shoes = createShoes(sport, size, color );
        return shoes;
    }
}
