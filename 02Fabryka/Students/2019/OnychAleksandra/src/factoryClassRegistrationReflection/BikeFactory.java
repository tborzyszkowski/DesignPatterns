package factoryClassRegistrationReflection;

import model.Bike;
import model.BikeType;

import java.lang.reflect.Constructor;
import java.lang.reflect.InvocationTargetException;
import java.util.HashMap;

public class BikeFactory {

    private static BikeFactory bikeFactory;
    private HashMap registeredBikes = new HashMap();

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

    public void registerBike(BikeType type, Class bikeClass) {
        registeredBikes.put(type, bikeClass);
    }

    public Bike createBike(BikeType type) throws NoSuchMethodException, IllegalAccessException, InvocationTargetException, InstantiationException {
        Class bikeClass = (Class) registeredBikes.get(type);
        Constructor bikeConstructor = bikeClass.getDeclaredConstructor(new Class[] {});
        return (Bike) bikeConstructor.newInstance(new Object[] { });
    }
}
