package MethodFactory.Factories;

import MethodFactory.Products.Shoes;

public abstract class MethodFactoryOrder {

    abstract Shoes createShoes(String sport, int size, String color);

    public Shoes orderShoes(String sport, int size, String color){
        return createShoes(sport, size, color);
    }
}
