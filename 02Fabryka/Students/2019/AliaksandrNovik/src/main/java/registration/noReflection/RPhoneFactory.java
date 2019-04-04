package registration.noReflection;

import java.util.HashMap;


public class RPhoneFactory {

	public static RPhoneFactory INSTANCE;
	
	public static RPhoneFactory getInstance() {
		if(INSTANCE==null) {
			INSTANCE = new RPhoneFactory();
		}
		return INSTANCE;
	}
	
	private HashMap<String, RSmartphone> registredProducts = new HashMap<>(); 

	public HashMap<String, RSmartphone> getRegistredProducts() {
		return registredProducts;
	}

	public void setRegistredProducts(HashMap<String, RSmartphone> registredProducts) {
		this.registredProducts = registredProducts;
	}

	public void registerProduct(String productId, RSmartphone p) {
		registredProducts.put(productId, p);
	}
	
	public RSmartphone createProduct(String idProduct) {
		InitFactory.initFactory(idProduct);
		return (RSmartphone)(registredProducts.get(idProduct).createPhone());
	}

	
}
