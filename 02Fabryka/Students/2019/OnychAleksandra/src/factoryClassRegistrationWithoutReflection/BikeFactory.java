package factoryClassRegistrationWithoutReflection;

import model.Bike;
import model.BikeType;

import java.util.HashMap;
import java.util.Map;
import java.util.function.Supplier;

public class BikeFactory {

    private static BikeFactory bikeFactory;
    private Map<BikeType, Supplier<? extends Bike>> registeredBikes = new HashMap();

    private BikeFactory() { }

    public static BikeFactory getInstance() {
        if (bikeFactory == null) {
            synchronized (BikeFactory.class) {
                if (bikeFactory == null) {
                    bikeFactory = new BikeFactory();
                }
            }
        }
        return bikeFactory;
    }

    public void registerBike(BikeType type, Supplier<? extends Bike> supplier) {
        registeredBikes.put(type, supplier);
    }

    public Bike createBike(BikeType type) {
        Supplier<? extends Bike> bike = registeredBikes.get(type);
        return bike != null ? bike.get() : null;
    }
}
