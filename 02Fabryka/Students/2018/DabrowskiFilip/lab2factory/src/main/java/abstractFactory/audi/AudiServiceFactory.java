package abstractFactory.audi;

import abstractFactory.CarChecker;
import abstractFactory.CarCleaner;
import abstractFactory.CarServiceFactory;

public class AudiServiceFactory extends CarServiceFactory {

    private static AudiServiceFactory audiServiceFactory;

    public static AudiServiceFactory getInstance() {
        if (audiServiceFactory == null) {
            audiServiceFactory = new AudiServiceFactory();
        }
        return audiServiceFactory;

    }

    @Override
    public CarChecker getCarChecker() {
        return new AudiCarChecker();
    }

    @Override
    public CarCleaner getCarCleaner() {
        return new AudiCarCleaner();
    }
}
