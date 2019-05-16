package factoryMethod;

import products.Teas.BlackTea;
import products.Teas.GreenTea;
import products.Teas.RedTea;
import products.Teas.WhiteTea;
import products.Teas.YerbaMate;
import products.Product;
import products.Tea;

public class TeasShop extends CoffeeShop {

	private static TeasShop instance;
	
	private TeasShop() {};
	
	public static TeasShop getInstance() {
		if(instance == null) {
			instance = new TeasShop();
		}
		return instance;
	}
	
	
	
	@Override
	Product makeProduct(String type) {
		type = type.toLowerCase();
		Tea tea = null;
		
		if(type.equals("white")) {
			tea = new WhiteTea();
		} else if(type.equals("green")) {
			tea = new GreenTea();
		} else if(type.equals("black")) {
			tea = new BlackTea();
		} else if (type.equals("red")) {
			tea  = new RedTea();
		} else if(type.equals("yerba")) {
			tea = new YerbaMate();
		}
		
		return tea;
	}

}
