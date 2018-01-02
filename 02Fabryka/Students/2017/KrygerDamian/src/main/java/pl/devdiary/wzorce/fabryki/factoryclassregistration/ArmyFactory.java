package pl.devdiary.wzorce.fabryki.factoryclassregistration;

import java.lang.reflect.InvocationTargetException;
import java.util.HashMap;

public class ArmyFactory {

    private static ArmyFactory instance;
    private HashMap<ArmyType, Class> registeredClasses = new HashMap<>();

    private ArmyFactory() {}

    public static ArmyFactory getInstance()
    {
        if(instance == null)
        {
            instance = new ArmyFactory();
        }
        return instance;
    }

    public void registerClass(ArmyType type, Class army)
    {
        registeredClasses.put(type, army);
    }

    public Army createArmy(ArmyType type) throws NoSuchMethodException, InvocationTargetException, IllegalAccessException {
        return (Army) registeredClasses.get(type).getMethod("createArmy").invoke(null);
    }

    public HashMap<ArmyType, Class> getRegisteredClasses() {
        return registeredClasses;
    }
}
