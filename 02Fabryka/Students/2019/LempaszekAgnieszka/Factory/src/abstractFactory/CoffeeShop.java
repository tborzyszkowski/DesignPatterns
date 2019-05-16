package abstractFactory;

import products.Tea;
import products.Cake;
import products.Coffee;

public class CoffeeShop {
	private AbstractFactory absFactory;
	
	public CoffeeShop(AbstractFactory absFactory) {
		this.absFactory = absFactory;
	}
	
	public Cake makeCake() {
		return absFactory.makeCake();
	}
	
	public Tea makeTea() {
		return absFactory.makeTea();
	}
	
	public Coffee makeCoffee() {
		return absFactory.makeCoffee();
	}
}
