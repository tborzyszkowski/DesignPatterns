package factoryMethod;

import products.Product;

public abstract class CoffeeShop {
	abstract Product makeProduct(String product);
	
	
	public Product make(String name) {
		Product product = makeProduct(name);
		return product;
	}
}
