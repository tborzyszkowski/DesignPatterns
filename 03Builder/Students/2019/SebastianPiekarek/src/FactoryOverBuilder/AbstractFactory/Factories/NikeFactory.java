package FactoryOverBuilder.AbstractFactory.Factories;


import FactoryOverBuilder.AbstractFactory.ComponentsFactory.BasketballComponentsFactory;
import FactoryOverBuilder.AbstractFactory.ComponentsFactory.FootballComponentsFactory;
import FactoryOverBuilder.AbstractFactory.ComponentsFactory.RunningComponentsFactory;
import FactoryOverBuilder.AbstractFactory.Products.NikeShoes.NikeBasketball;
import FactoryOverBuilder.AbstractFactory.Products.NikeShoes.NikeFootball;
import FactoryOverBuilder.AbstractFactory.Products.NikeShoes.NikeRunning;
import FactoryOverBuilder.AbstractFactory.Products.Shoes;


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
