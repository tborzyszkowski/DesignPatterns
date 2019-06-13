package abstractFactory.factories;

import abstractFactory.components.CasualWatchComponentsFactory;
import abstractFactory.components.PremiumWatchComponentsFactory;
import abstractFactory.components.SportWatchComponentsFactory;
import abstractFactory.products.*;

import static abstractFactory.products.WatchTypes.CASUAL_WATCH;
import static abstractFactory.products.WatchTypes.PREMIUM_WATCH;
import static abstractFactory.products.WatchTypes.SPORT_WATCH;

public class SwissFactory extends AbstractWatchFactory {

    private final String producer = "Switzerland";

    private static SwissFactory swissFactory;

    private SwissFactory(){};

    public static SwissFactory getSwissFactoryInstance(){
        if(swissFactory == null) swissFactory = new SwissFactory();
        return swissFactory;
    }

    @Override
    public Watch createWatch(WatchTypes type) {

        if (type == CASUAL_WATCH) {
            return new JapaneseCasualWatch(producer, 1300f, new CasualWatchComponentsFactory());
        } else if (type == SPORT_WATCH) {
            return new JapaneseSportWatch(producer, 1500f, new SportWatchComponentsFactory());
        } else if (type == PREMIUM_WATCH){
            return new JapanesePremiumWatch(producer, 3500f, new PremiumWatchComponentsFactory());
        } else {
            return null;
        }

    }
}
