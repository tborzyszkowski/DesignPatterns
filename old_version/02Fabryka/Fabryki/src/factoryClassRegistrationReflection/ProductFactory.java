package factoryClassRegistrationReflection;

import java.lang.reflect.Constructor;
import java.lang.reflect.InvocationTargetException;
import java.util.HashMap;

class ProductFactory
{
	private HashMap m_RegisteredProducts = new HashMap();

	public void registerProduct (String productID, Class productClass)
	{
		m_RegisteredProducts.put(productID, productClass);
	}

	public Product createProduct(String productID) throws NoSuchMethodException, SecurityException, InstantiationException, IllegalAccessException, IllegalArgumentException, InvocationTargetException
	{
		Class productClass = (Class)m_RegisteredProducts.get(productID);
		Constructor productConstructor = productClass.getDeclaredConstructor(new Class[] { String.class });
		return (Product)productConstructor.newInstance(new Object[] { });
	}
}
