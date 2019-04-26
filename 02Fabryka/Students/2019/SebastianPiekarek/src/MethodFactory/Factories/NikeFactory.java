package MethodFactory.Factories;


import MethodFactory.Products.NikeShoes.*;
import MethodFactory.Products.Shoes;

public class NikeFactory extends MethodFactoryOrder {

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
                return new NikeRunning(size, color, brand);
            case ("Koszykówka") :
                return new NikeBasketball(size, color, brand);
            case ("Piłka nożna") :
                return new NikeFootball(size, color, brand);
        }
        return null;
    }
}
