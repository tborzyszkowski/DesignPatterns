package FactoryOverBuilder.AbstractFactory.Factories;


import FactoryOverBuilder.AbstractFactory.ComponentsFactory.BasketballComponentsFactory;
import FactoryOverBuilder.AbstractFactory.ComponentsFactory.FootballComponentsFactory;
import FactoryOverBuilder.AbstractFactory.ComponentsFactory.RunningComponentsFactory;
import FactoryOverBuilder.AbstractFactory.Products.AdidasShoes.AdidasBasketball;
import FactoryOverBuilder.AbstractFactory.Products.AdidasShoes.AdidasFootball;
import FactoryOverBuilder.AbstractFactory.Products.AdidasShoes.AdidasRunning;
import FactoryOverBuilder.AbstractFactory.Products.Shoes;

public class AdidasFactory extends AbstractFactoryOrder {

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
                return new AdidasRunning(size, color, brand, new RunningComponentsFactory());
            case ("Koszykówka") :
                return new AdidasBasketball(size, color, brand, new BasketballComponentsFactory());
            case ("Piłka nożna") :
                return new AdidasFootball(size, color, brand, new FootballComponentsFactory());
        }
        return null;
    }
}
