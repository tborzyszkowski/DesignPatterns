package factoryMethod;

import products.Cakes.BirthdayCake;
import products.Cakes.CheeseCake;
import products.Cakes.ChocolateCake;
import products.Cakes.RaspberryCake;
import products.Cakes.VanillaCake;
import products.Cake;
import products.Product;

public class CakesShop extends CoffeeShop {
	
	private static CakesShop instance;
	
	private CakesShop() {}
	
	public static CakesShop getInstance() {
		if(instance == null) {
			instance = new CakesShop();
		}
		return instance;
	}

	@Override
	Product makeProduct(String type) {
		type = type.toLowerCase();
		Cake cake = null;
		
		if(type.equals("cheese")) {
			cake = new CheeseCake();
		} else if(type.equals("chocolate")) {
			cake = new ChocolateCake();
		} else if(type.equals("raspberry")) {
			cake = new RaspberryCake();
		} else if(type.equals("birthday")) {
			cake = new BirthdayCake();
		} else if (type.equals("vanilla")) {
			cake = new VanillaCake();
		}
		
		return cake;
	}

	
}
