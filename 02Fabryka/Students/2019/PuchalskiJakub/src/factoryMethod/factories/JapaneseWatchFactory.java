package factoryMethod.factories;

import factoryMethod.products.*;

public class JapaneseWatchFactory extends WatchFactory{

    private final String producer = "Japan";

    private static JapaneseWatchFactory japaneseWatchFactory;

    public static JapaneseWatchFactory getJapaneseWatchFactoryInstance() {
        if(japaneseWatchFactory == null) japaneseWatchFactory = new JapaneseWatchFactory();
        return japaneseWatchFactory;
    }

    @Override
    protected Watch createWatch(WatchTypes type) {
        if (type == WatchTypes.CASUAL_WATCH){
            return new JapaneseCasualWatch(producer, 1000f, WatchTypes.CASUAL_WATCH.toString());
        } else if (type == WatchTypes.SPORT_WATCH){
            return new JapaneseSportWatch(producer, 1100f, WatchTypes.SPORT_WATCH.toString());
        } else if (type == WatchTypes.PREMIUM_WATCH){
            return new JapanesePremiumWatch(producer,3000f, WatchTypes.PREMIUM_WATCH.toString());
        } else {
            return null;
        }
    }
}
