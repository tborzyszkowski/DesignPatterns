package engine.registry.decorators;

import engine.registry.RegistryPrinter;

import java.lang.reflect.Constructor;
import java.util.HashMap;
import java.util.Set;

/**
 * Created by jakub on 1/20/17.
 */
public enum DecoratorRegistry {
    INSTANCE;

    HashMap<String, Class<? extends RegistryDecorator>> decoratorRegistry = new HashMap<>();

    public void registerRegistryDecorator(String decoratorName, Class<? extends RegistryDecorator> decorator) {
        decoratorRegistry.put(decoratorName, decorator);
    }

    public RegistryDecorator createRegistryDecorator(String decoratorName, RegistryPrinter decorated) throws Exception {
        if(decoratorName == null || decoratorRegistry.get(decoratorName) == null) {
            throw new Exception("no such decorator");
        }

        Class decoratorClass = decoratorRegistry.get(decoratorName);
        Constructor productConstructor = decoratorClass.getDeclaredConstructor(new Class[] { RegistryPrinter.class });
        return (RegistryDecorator)productConstructor.newInstance(decorated);
    }

    @Override
    public String toString() {
        return super.toString();
    }
}
