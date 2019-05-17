package AbstractFactory.Factories;

import AbstractFactory.Products.Shoes;

public abstract class AbstractFactoryOrder {

    abstract Shoes createShoes(String sport, int size, String color);

    public Shoes orderShoes(String sport, int size, String color){
        return createShoes(sport, size, color );
    }
}
