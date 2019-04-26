package ClassRegistration.Reflection;

import ClassRegistration.Reflection.Products.Shoes;

import java.lang.reflect.InvocationTargetException;
import java.util.HashMap;

public class ReflectionFactory {

    private static ReflectionFactory reflectionFactory;
    private HashMap m_RegisteredProducts = new HashMap();


    private ReflectionFactory(){}


    public static ReflectionFactory getReflectionFactory() {
        if(reflectionFactory == null) reflectionFactory = new ReflectionFactory();
        return reflectionFactory;
    }

    public void registerProduct (String productID, Class productClass)
    {
        m_RegisteredProducts.put(productID, productClass);
    }

    public Shoes createProduct(String sport) throws NoSuchMethodException, SecurityException, InstantiationException, IllegalAccessException, IllegalArgumentException, InvocationTargetException
    {
        Class productClass = (Class)m_RegisteredProducts.get(sport);
        return (Shoes)productClass.getDeclaredConstructor().newInstance();
    }
}
