package AbstractFactory.Factories;


import AbstractFactory.ComponentsFactory.*;
import AbstractFactory.Products.NikeShoes.NikeBasketball;
import AbstractFactory.Products.NikeShoes.NikeFootball;
import AbstractFactory.Products.NikeShoes.NikeRunning;
import AbstractFactory.Products.Shoes;


public class NikeFactory extends AbstractFactoryOrder {

    private final String brand = "NIKE";
    private static NikeFactory nikeFactory;

    private NikeFactory(){}

    public static NikeFactory getNikeFactory() {
        if(nikeFactory == null) nikeFactory = new NikeFactory();
        return nikeFactory;
    }

    Shoes createShoes(String sport, int size, String color){

        switch(sport){
            case ("Bieganie") :
                return new NikeRunning(size, color, brand, new RunningComponentsFactory());
            case ("Koszykówka") :
                return new NikeBasketball(size, color, brand, new BasketballComponentsFactory());
            case ("Piłka nożna") :
                return new NikeFootball(size, color, brand, new FootballComponentsFactory());
        }
        return null;
    }
}
