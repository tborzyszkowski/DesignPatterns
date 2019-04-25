package simple;

import model.*;

public class SimpleBikeFactory {
    private static SimpleBikeFactory simpleBikeFactory;

    private SimpleBikeFactory() { }

    public static SimpleBikeFactory getInstance() {
        if (simpleBikeFactory == null) {
            synchronized (SimpleBikeFactory.class) {
                if (simpleBikeFactory == null) {
                    simpleBikeFactory = new SimpleBikeFactory();
                }
            }
        }
        return simpleBikeFactory;
    }

    public Bike createBike(BikeType type) {
        switch (type) {
            case CITY:
                return new CityBike();
            case CROSS:
                return new CrossBike();
            case ELECTRIC:
                return new ElectricBike();
            case KIDS:
                return new KidsBike();
            case MOUNTAIN:
                return new MountainBike();
            default:
                return null;
        }
    }
}
