package factoryClassRegistration;

import java.util.HashMap;

class ProductFactory
{
	private HashMap<String, Class> m_RegisteredProducts = new HashMap();

	public void registerProduct (String productID, Class productClass)
	{
		m_RegisteredProducts.put(productID, productClass);
	}
	public void registerProduct(String productID, Product p)    {
		m_RegisteredProducts.put(productID, p.getClass());
	}

	public Product createProduct(String productID){
		return ((Product)m_RegisteredProducts.get(productID)).createProduct();
	}
}
