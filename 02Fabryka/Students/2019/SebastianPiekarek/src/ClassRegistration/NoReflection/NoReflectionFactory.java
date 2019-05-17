package ClassRegistration.NoReflection;

import ClassRegistration.NoReflection.Products.Shoes;

import java.util.HashMap;

public class NoReflectionFactory {

    private static NoReflectionFactory noReflectionFactory;
    public static  HashMap<String,Shoes> m_RegisteredProducts = new HashMap();

    private NoReflectionFactory(){}

    public static NoReflectionFactory getNoReflectionFactory() {
        if(noReflectionFactory == null) noReflectionFactory = new NoReflectionFactory();
        return noReflectionFactory;
    }


    public void registerProduct(String productID, Shoes shoesClass)    {
        m_RegisteredProducts.put(productID, shoesClass);
    }

    public Shoes createShoes(String productID){
        RegisterClass.register(productID);
        return (m_RegisteredProducts.get(productID)).createProduct();
    }

}