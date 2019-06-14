package factoryMethod.factories;

import factoryMethod.products.*;

public class SwissWachFacotry extends WatchFactory {

    private final String producer = "Switzerland";

    private static SwissWachFacotry swissWatchFactory;

    public static SwissWachFacotry getSwissWatchFactoryInstance() {
        if(swissWatchFactory == null) swissWatchFactory = new SwissWachFacotry();
        return swissWatchFactory;
    }

    @Override
    protected Watch createWatch(WatchTypes type) {
        if (type == WatchTypes.CASUAL_WATCH){
            return new SwissCasualWatch(producer, 1300f, WatchTypes.CASUAL_WATCH.toString());
        } else if (type == WatchTypes.SPORT_WATCH){
            return new SwissSportWatch(producer, 1500f, WatchTypes.SPORT_WATCH.toString());
        } else if (type == WatchTypes.PREMIUM_WATCH){
            return new SwissPremiumWatch(producer,4000f, WatchTypes.PREMIUM_WATCH.toString());
        } else {
            return null;
        }
    }
}
