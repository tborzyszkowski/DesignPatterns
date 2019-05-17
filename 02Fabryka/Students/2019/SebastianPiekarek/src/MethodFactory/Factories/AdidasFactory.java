package MethodFactory.Factories;


import MethodFactory.Products.AdidasShoes.AdidasBasketball;
import MethodFactory.Products.AdidasShoes.AdidasFootball;
import MethodFactory.Products.AdidasShoes.AdidasRunning;
import MethodFactory.Products.Shoes;

public class AdidasFactory extends MethodFactoryOrder {

    private final String brand = "ADIDAS";
    private static AdidasFactory adidasFactory;

    private AdidasFactory(){}

    public static AdidasFactory getAdidasFactory() {
        if(adidasFactory == null){
            adidasFactory = new AdidasFactory();
        }
        return adidasFactory;
    }

    Shoes createShoes(String sport, int size, String color){
        
        switch(sport){
            case ("Bieganie") :
                return new AdidasRunning(size, color, brand);
            case ("Koszykówka") :
                return new AdidasBasketball(size, color, brand);
            case ("Piłka nożna") :
                return new AdidasFootball(size, color, brand);
        }
        return null;
    }
}
