package factoryClassRegistrationWithoutReflection;

import model.Bike;
import model.BikeType;

import java.lang.reflect.InvocationTargetException;

public class BikeShop {
    private BikeFactory bikeFactory;

    public BikeShop(BikeFactory bikeFactory) {
        this.bikeFactory = bikeFactory.getInstance();
    }

    public Bike makeBike(BikeType type) throws InvocationTargetException, NoSuchMethodException, InstantiationException, IllegalAccessException {
        Bike bike = bikeFactory.createBike(type);

        if (bike != null) {
            bike.prepareParts();
        }

        return bike;
    }
}
