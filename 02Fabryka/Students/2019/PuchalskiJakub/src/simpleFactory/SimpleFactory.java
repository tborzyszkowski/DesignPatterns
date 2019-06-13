package simpleFactory;

import simpleFactory.products.*;

public class SimpleFactory {

    private static SimpleFactory instance;

    public static SimpleFactory getInstance(){
        if(instance == null){
            instance = new SimpleFactory();
        }
        return instance;
    }

    public Watch createWatch(WatchTypes type) {

        if (type.equals(WatchTypes.PREMIUM_WATCH)){
            return new PremiumWatch();
        } else if (type.equals(WatchTypes.CASUAL_WATCH)){
            return new CasualWatch();
        } else if (type.equals(WatchTypes.SPORT_WATCH)){
            return new SportWatch();
        } else {
            return null;
        }

    }

}
