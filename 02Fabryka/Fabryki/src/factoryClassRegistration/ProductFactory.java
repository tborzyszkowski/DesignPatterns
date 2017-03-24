package factoryClassRegistration;

import java.util.HashMap;

class ProductFactory
{
	private HashMap m_RegisteredProducts = new HashMap();

	public void registerProduct (String productID, Class productClass)
	{
		m_RegisteredProducts.put(productID, productClass);
	}
	public void registerProduct(String productID, Product p)    {
		m_RegisteredProducts.put(productID, p);
	}

	public Product createProduct(String productID){
		return ((Product)m_RegisteredProducts.get(productID)).createProduct();
	}
}
