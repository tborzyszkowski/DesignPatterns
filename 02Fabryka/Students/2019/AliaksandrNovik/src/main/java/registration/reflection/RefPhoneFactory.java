package registration.reflection;

import java.lang.reflect.Constructor;
import java.lang.reflect.InvocationTargetException;
import java.util.HashMap;

import registration.noReflection.InitFactory;
import registration.noReflection.RSmartphone;
import registration.noReflection.smartphones.RHuaweiFold;
import registration.noReflection.smartphones.RHuaweiGaming;

@SuppressWarnings("rawtypes")
public class RefPhoneFactory {

	public static RefPhoneFactory INSTANCE;
	
	public static RefPhoneFactory getInstance() {
		if(INSTANCE==null) {
			INSTANCE = new RefPhoneFactory();
		}
		return INSTANCE;
	}
	
	
	private HashMap<String, Class> registredProducts = new HashMap<>(); 

	public HashMap<String, Class> getRegistredProducts() {
		return registredProducts;
	}

	public void setRegistredProducts(HashMap<String, Class> registredProducts) {
		this.registredProducts = registredProducts;
	}

	public void registerProduct(String productId, Class c) {
		registredProducts.put(productId, c);
	}

	public void initFactory() {
		registredProducts.put("rHuaweiGamingId",RHuaweiGaming.class);
		registredProducts.put("rHuaweiFoldId",RHuaweiFold.class);
	}
	
	@SuppressWarnings("unchecked")
	public RSmartphone createProduct(String idProduct) throws NoSuchMethodException, SecurityException, InstantiationException, IllegalAccessException, IllegalArgumentException, InvocationTargetException {
		Class clazz = (Class)registredProducts.get(idProduct);		
		Constructor constructor = clazz.getConstructor(null);
		return (RSmartphone)constructor.newInstance(null);
	}

}
