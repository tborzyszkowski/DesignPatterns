package abstractFactory.factories;

import abstractFactory.components.CasualWatchComponentsFactory;
import abstractFactory.components.PremiumWatchComponentsFactory;
import abstractFactory.components.SportWatchComponentsFactory;
import abstractFactory.products.*;

import static abstractFactory.products.WatchTypes.*;

public class JapaneseFactory extends AbstractWatchFactory {

    private final String producer = "Japan";

    private static JapaneseFactory japaneseFactory;

    private JapaneseFactory(){};

    public static JapaneseFactory getJapaneseFactoryInstance(){
        if(japaneseFactory == null) japaneseFactory = new JapaneseFactory();
            return japaneseFactory;
    }

    @Override
    public Watch createWatch(WatchTypes type) {

        if (type == CASUAL_WATCH) {
            return new JapaneseCasualWatch(producer, 1000f, new CasualWatchComponentsFactory());
        } else if (type == SPORT_WATCH) {
            return new JapaneseSportWatch(producer, 1100f, new SportWatchComponentsFactory());
        } else if (type == PREMIUM_WATCH){
            return new JapanesePremiumWatch(producer, 3000f, new PremiumWatchComponentsFactory());
        } else {
            return null;
        }
    }
}
