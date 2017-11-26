package pl.devdiary.wzorce.singleton.test;

import org.junit.Assert;
import org.junit.Test;
import pl.devdiary.wzorce.singleton.DefaultSafeSingleton;
import pl.devdiary.wzorce.singleton.ReflexionSafeSingleton;
import pl.devdiary.wzorce.singleton.SynchronizedSingleton;

import java.lang.reflect.Constructor;
import java.lang.reflect.InvocationTargetException;

public class ReflexionTest {

    @Test
    public void getNotThreadSafeSingletonByReflexion() throws NoSuchMethodException, IllegalAccessException, InstantiationException, InvocationTargetException {
        DefaultSafeSingleton singleton = DefaultSafeSingleton.getInstance();

        Constructor<DefaultSafeSingleton> constructor = DefaultSafeSingleton.class.getDeclaredConstructor();
        constructor.setAccessible(true);
        DefaultSafeSingleton secondInstance = constructor.newInstance();

        Assert.assertNotEquals(singleton, secondInstance);
    }

    @Test
    public void getSynchronizedSingletonByReflexion() throws NoSuchMethodException, IllegalAccessException, InvocationTargetException, InstantiationException {
        SynchronizedSingleton singleton = SynchronizedSingleton.getInstance();

        Constructor<SynchronizedSingleton> constructor = SynchronizedSingleton.class.getDeclaredConstructor();
        constructor.setAccessible(true);
        SynchronizedSingleton secondInstance = constructor.newInstance();

        Assert.assertNotEquals(singleton, secondInstance);
    }

    @Test(expected = InvocationTargetException.class)
    public void getReflexionSafeSingletonByReflexion() throws NoSuchMethodException, IllegalAccessException, InvocationTargetException, InstantiationException {
        ReflexionSafeSingleton singleton = ReflexionSafeSingleton.getInstance();

        Constructor<ReflexionSafeSingleton> constructor = ReflexionSafeSingleton.class.getDeclaredConstructor();
        constructor.setAccessible(true);
        ReflexionSafeSingleton secondInstance = constructor.newInstance();

        Assert.assertNotEquals(singleton, secondInstance);
    }
}
