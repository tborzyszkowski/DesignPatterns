package abstractFactory;

import products.Cake;
import products.Cakes.CheeseCake;
import products.Coffee;
import products.Coffees.BlackCoffee;
import products.Tea;
import products.Teas.BlackTea;

public class CheapDessertsFactory implements AbstractFactory {
	private static CheapDessertsFactory instance;
	
	private CheapDessertsFactory() {}
	
	public static CheapDessertsFactory getInstance() {
		if(instance == null) {
			instance = new CheapDessertsFactory();
		}
		return instance;
	}
	

	@Override
	public Cake makeCake() {
		Cake cake = new CheeseCake();
		return cake;
	}

	@Override
	public Coffee makeCoffee() {
		Coffee coffee = new BlackCoffee();
		return coffee;
	}

	@Override
	public Tea makeTea() {
		Tea tea = new BlackTea();
		return tea;
	}

}
