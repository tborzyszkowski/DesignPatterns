package abstractFactory;

import abstractFactory.factories.JapaneseFactory;
import abstractFactory.factories.SwissFactory;
import abstractFactory.products.Watch;
import abstractFactory.products.WatchTypes;

public class AbstractFactoryMain {
    public static void main(String[] args) {

        SwissFactory swissFactory = SwissFactory.getSwissFactoryInstance();
        JapaneseFactory japaneseFactory = JapaneseFactory.getJapaneseFactoryInstance();

        Watch swissCasualWatch = swissFactory.createWatch(WatchTypes.CASUAL_WATCH);
        Watch swissSportWatch = swissFactory.createWatch(WatchTypes.SPORT_WATCH);
        Watch swissPremiumWatch = swissFactory.createWatch(WatchTypes.PREMIUM_WATCH);

        Watch japaneseCasualWatch = japaneseFactory.createWatch(WatchTypes.CASUAL_WATCH);
        Watch japaneseSportWatch = japaneseFactory.createWatch(WatchTypes.SPORT_WATCH);
        Watch japanesePremiumWatch = japaneseFactory.createWatch(WatchTypes.PREMIUM_WATCH);

        System.out.println(swissCasualWatch.toString());
        System.out.println(japaneseCasualWatch.toString());
    }
}
