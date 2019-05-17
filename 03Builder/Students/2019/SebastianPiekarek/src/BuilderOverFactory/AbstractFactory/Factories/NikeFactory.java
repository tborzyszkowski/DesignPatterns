package BuilderOverFactory.AbstractFactory.Factories;


import BuilderOverFactory.AbstractFactory.ComponentsFactory.FootballComponentsFactory;
import BuilderOverFactory.AbstractFactory.Products.NikeShoes.NikeFootball;
import BuilderOverFactory.AbstractFactory.Products.Shoes;

public class NikeFactory extends AbstractFactoryOrder {

    private final String brand = "NIKE";
    private static NikeFactory nikeFactory;

    private NikeFactory(){}

    public static NikeFactory getNikeFactory() {
        if(nikeFactory == null) nikeFactory = new NikeFactory();
        return nikeFactory;
    }

    Shoes createShoes(String sport, int size, String color, int price){

        switch(sport){
            case ("Piłka nożna") :
                return new NikeFootball( brand, size, color, price, new FootballComponentsFactory());
        }
        return null;
    }
}
