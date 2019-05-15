package factoryMethod.factory;

import factoryMethod.polishBikes.*;
import model.Bike;
import model.BikeType;

public class PolishBikeFactory extends BikeFactory {
    private static PolishBikeFactory polishBikeFactory;

    private PolishBikeFactory() { }

    public static PolishBikeFactory getInstance() {
        if (polishBikeFactory == null) {
            synchronized (PolishBikeFactory.class) {
                if (polishBikeFactory == null) {
                    polishBikeFactory = new PolishBikeFactory();
                }
            }
        }
        return polishBikeFactory;
    }

    Bike createBike(BikeType type) {
        switch (type) {
            case CITY:
                return new PolishCityBike();
            case CROSS:
                return new PolishCrossBike();
            case ELECTRIC:
                return new PolishElectricBike();
            case KIDS:
                return new PolishKidsBike();
            case MOUNTAIN:
                return new PolishMountainBike();
            default:
                return null;
        }
    }
}
