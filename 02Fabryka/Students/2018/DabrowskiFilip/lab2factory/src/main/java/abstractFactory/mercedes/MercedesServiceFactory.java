package abstractFactory.mercedes;

import abstractFactory.CarChecker;
import abstractFactory.CarCleaner;
import abstractFactory.CarServiceFactory;

public class MercedesServiceFactory extends CarServiceFactory {

    private static MercedesServiceFactory mercedesServiceFactory;

    public static MercedesServiceFactory getInstance() {
        if (mercedesServiceFactory == null) {
            mercedesServiceFactory = new MercedesServiceFactory();
        }
        return mercedesServiceFactory;
    }

    @Override
    public CarChecker getCarChecker() {
        return new MercedesCarChecker();
    }

    @Override
    public CarCleaner getCarCleaner() {
        return new MercedesCarCleaner();
    }
}
