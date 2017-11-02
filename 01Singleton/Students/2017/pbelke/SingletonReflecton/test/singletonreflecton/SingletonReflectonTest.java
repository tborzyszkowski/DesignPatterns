package singletonreflecton;

import java.lang.reflect.InvocationTargetException;
import org.junit.Assert;
import org.junit.Test;

/**
 *
 * @author pbelke
 */
public class SingletonReflectonTest {
    
    @Test(expected = InvocationTargetException.class)
    public void testGetSingletonExceptionInstance() throws Exception {
        SingletonException instance1 = SingletonException.getInstance();
        SingletonException result = SingletonReflecton.getSingletonExceptionInstance();
    }
    
    @Test
    public void testGetSingletonInstance() {
        Singleton instance1 = Singleton.getInstance();
        Singleton result = SingletonReflecton.getSingletonInstance();
        
        Assert.assertNotEquals(instance1.hashCode(), result.hashCode());
    }
}
