package simpleFactory;

import simpleFactory.products.Watch;
import simpleFactory.products.WatchTypes;

public class SimpleFactoryMain {

    public static void main(String[] args) {

        SimpleFactory simpleFactory = SimpleFactory.getInstance();

        Watch CasualWatch = simpleFactory.createWatch(WatchTypes.CASUAL_WATCH);
        Watch PremiumWatch = simpleFactory.createWatch(WatchTypes.PREMIUM_WATCH);
        Watch SportWatch = simpleFactory.createWatch(WatchTypes.SPORT_WATCH);

        System.out.println(CasualWatch.toString());
        System.out.println(PremiumWatch.toString());
        System.out.println(SportWatch.toString());
    }

}
