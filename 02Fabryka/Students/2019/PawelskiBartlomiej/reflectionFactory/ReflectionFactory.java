package reflectionFactory;

import computers.*;

import java.lang.reflect.Constructor;
import java.lang.reflect.InvocationTargetException;
import java.util.HashMap;

public enum ReflectionFactory {
    INSTANCE;
    private HashMap<String, Class<? extends Computer>> registeredTypes = new HashMap<>();

    public void registerType(String hash, Class<? extends Computer> _class) {
        registeredTypes.put(hash, _class);
    }

    public Computer getComputer(String hash) throws NoSuchMethodException, IllegalAccessException, InvocationTargetException, InstantiationException {
        Class<?> _class = registeredTypes.get(hash);
        Constructor computerConstructor = _class.getDeclaredConstructor();
        return (Computer) computerConstructor.newInstance(new Object[]{});
    }
}
