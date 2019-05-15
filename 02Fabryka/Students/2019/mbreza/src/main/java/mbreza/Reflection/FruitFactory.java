package mbreza.Reflection;

import java.lang.reflect.Constructor;
import java.lang.reflect.InvocationTargetException;
import java.util.HashMap;

public class FruitFactory {

    private static FruitFactory instance = null;

    private FruitFactory() {
    }

    public static FruitFactory createInstance(){
        if(instance == null) {
            instance = new FruitFactory();
        }
        return instance;
    }

    private HashMap<String, Class> fruitTypes = new HashMap<>();


    //do testów
    public HashMap<String, Class> getFruitTypes() {
        return fruitTypes;
    }

    public void addFruit (String fruitName, Class fruitClass) {
        fruitTypes.put(fruitName, fruitClass);
    }

    public Fruit createFruit(String fruitName) throws NoSuchMethodException, IllegalAccessException,
                                                        InvocationTargetException, InstantiationException {
        Class fruitClass = fruitTypes.get(fruitName);
        Constructor fruitConstructor = fruitClass.getConstructor();
        return (Fruit)fruitConstructor.newInstance();
    }
}
