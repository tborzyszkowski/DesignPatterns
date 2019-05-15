package factoryMethod.factory;

import factoryMethod.germanBikes.*;
import model.Bike;
import model.BikeType;

public class GermanBikeFactory extends BikeFactory {

    private static GermanBikeFactory germanBikeFactory;

    private GermanBikeFactory() { }

    public static GermanBikeFactory getInstance() {
        if (germanBikeFactory == null) {
            synchronized (GermanBikeFactory.class) {
                if (germanBikeFactory == null) {
                    germanBikeFactory = new GermanBikeFactory();
                }
            }
        }
        return germanBikeFactory;
    }

    Bike createBike(BikeType type) {
        switch (type) {
            case CITY:
                return new GermanCityBike();
            case CROSS:
                return new GermanCrossBike();
            case ELECTRIC:
                return new GermanElectricBike();
            case KIDS:
                return new GermanKidsBike();
            case MOUNTAIN:
                return new GermanMountainBike();
            default:
                return null;
        }
    }
}
