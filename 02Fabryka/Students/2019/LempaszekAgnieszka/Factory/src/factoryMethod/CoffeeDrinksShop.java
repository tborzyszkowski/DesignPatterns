package factoryMethod;

import products.Coffees.Americano;
import products.Coffees.BlackCoffee;
import products.Coffees.Cappuccino;
import products.Coffees.Espresso;
import products.Coffees.Latte;
import products.Coffee;
import products.Product;

public class CoffeeDrinksShop extends CoffeeShop {
	private static CoffeeDrinksShop instance;
	
	private CoffeeDrinksShop() {}
	
	public static CoffeeDrinksShop getInstance() {
		if(instance == null) {
			instance = new CoffeeDrinksShop();
		}
		return instance;
	}
	
	@Override
	Product makeProduct(String type) {
		type = type.toLowerCase();
		Coffee coffee = null;
		
		if(type.equals("cappuccino")) {
			coffee = new Cappuccino();
		} else if(type.equals("latte")) {
			coffee = new Latte();
		} else if(type.equals("black")) {
			coffee = new BlackCoffee();
		} else if (type.equals("americano")) {
			coffee = new Americano();
		} else if(type.equals("espresso")) {
			coffee = new Espresso();
		}
		
		return coffee;
	}
}
