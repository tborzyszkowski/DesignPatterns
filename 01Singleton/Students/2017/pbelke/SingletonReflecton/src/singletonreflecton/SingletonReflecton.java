package singletonreflecton;

import java.lang.reflect.Constructor;
import java.lang.reflect.InvocationTargetException;

/**
 *
 * @author pbelke
 */
public class SingletonReflecton {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws Exception {
        Singleton singleton1 = Singleton.getInstance();
        Singleton singleton2 = getSingletonInstance();
        
        System.out.println("Instance 1 hash:" + singleton1.hashCode());
        System.out.println("Instance 2 hash:" + singleton2.hashCode());
        
        SingletonException instance1 = SingletonException.getInstance();
        SingletonException instance2 = getSingletonExceptionInstance();
    }
    
    public static SingletonException getSingletonExceptionInstance() throws Exception{
        SingletonException instance2 = null;
        try {
            Class<SingletonException> clazz = SingletonException.class;
            Constructor<SingletonException> cons = clazz.getDeclaredConstructor();
            cons.setAccessible(true);
            instance2 = cons.newInstance();
        } catch (NoSuchMethodException | InvocationTargetException | IllegalAccessException | InstantiationException e) {
            throw e;
        }
        return instance2;
    }
    
    public static Singleton getSingletonInstance(){
        Singleton instance2 = null;
        try {
            Class<Singleton> clazz = Singleton.class;
            Constructor<Singleton> cons = clazz.getDeclaredConstructor();
            cons.setAccessible(true);
            instance2 = cons.newInstance();
        } catch (NoSuchMethodException | InvocationTargetException | IllegalAccessException | InstantiationException e) {
            e.printStackTrace();
        }
        return instance2;
    }
}
