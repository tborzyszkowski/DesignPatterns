package BuilderOverFactory.AbstractFactory.Factories;

import BuilderOverFactory.AbstractFactory.Products.Shoes;

public abstract class AbstractFactoryOrder {

    abstract Shoes createShoes(String sport, int size, String color, int price);

    public Shoes orderShoes(String sport, int size, String color, int price){
        Shoes shoes = createShoes(sport, size, color, price);

        return shoes;
    }
}
