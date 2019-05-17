package SimpleFactory;

import SimpleFactory.Products.*;

public class SimpleFactory {

    private static SimpleFactory simpleFactory;

    private SimpleFactory(){}

    public static SimpleFactory getInstance() {
        if(simpleFactory == null){
            simpleFactory = new SimpleFactory();
        }
        return simpleFactory;
    }

    public Shoes createShoes(String sport){
        switch(sport){
            case ("Bieganie") :
                return new RunningShoes();
            case ("Koszykówka") :
                return new BasketballShoes();
            case ("Piłka nożna") :
                return new FootballShoes();
        }
        return null;
    }
}

