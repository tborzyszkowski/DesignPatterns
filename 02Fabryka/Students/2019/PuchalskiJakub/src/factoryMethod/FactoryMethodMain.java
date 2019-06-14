package factoryMethod;


import factoryMethod.factories.JapaneseWatchFactory;
import factoryMethod.factories.SwissWachFacotry;
import factoryMethod.products.Watch;
import factoryMethod.products.WatchTypes;

public class FactoryMethodMain {
    public static void main(String[] args) {
        SwissWachFacotry swissFactory = SwissWachFacotry.getSwissWatchFactoryInstance();
        JapaneseWatchFactory japaneseFactory = JapaneseWatchFactory.getJapaneseWatchFactoryInstance();

        Watch swissCasualWatch = swissFactory.getWatch(WatchTypes.CASUAL_WATCH);
        Watch swissSportWatch = swissFactory.getWatch(WatchTypes.SPORT_WATCH);
        Watch swissPremiumWatch = swissFactory.getWatch(WatchTypes.PREMIUM_WATCH);

        Watch japaneseCasualWatch = japaneseFactory.getWatch(WatchTypes.CASUAL_WATCH);
        Watch japaneseSportWatch = japaneseFactory.getWatch(WatchTypes.SPORT_WATCH);
        Watch japanesePremiumWatch = japaneseFactory.getWatch(WatchTypes.PREMIUM_WATCH);

        System.out.println(swissCasualWatch.toString());
        System.out.println(japaneseCasualWatch.toString());
    }
}
