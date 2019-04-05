package FactoryReflection;

import Products.Car;

import java.lang.reflect.Constructor;
import java.lang.reflect.InvocationTargetException;
import java.util.HashMap;
import java.util.Map;

public class ReflectionCarFactory {
    private static ReflectionCarFactory instance;
    private Map<String, Class<? extends Car>> registeredTypes = new HashMap<>();

    private ReflectionCarFactory() {}

    public static ReflectionCarFactory getInstance() {
        if(instance == null)
            instance = new ReflectionCarFactory();
        return instance;
    }


    public void registerType(String type, Class<? extends Car> _class) {
        registeredTypes.put(type, _class);
    }

    public Car getCar(String type) throws NoSuchMethodException, IllegalAccessException, InvocationTargetException, InstantiationException {
        Class<?> cClass = registeredTypes.get(type);
        Constructor carConstructor = cClass.getDeclaredConstructor();
        return (Car)carConstructor.newInstance(new Object[] {});
    }
}
