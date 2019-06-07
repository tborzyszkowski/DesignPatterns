package abstractFactory;

import products.Cake;
import products.Cakes.ChocolateCake;
import products.Tea;
import products.Teas.GreenTea;
import products.Coffee;
import products.Coffees.Latte;

public class SmallDessertsFactory implements AbstractFactory {
	private static SmallDessertsFactory instance;
	
	private SmallDessertsFactory() {}
	
	public static SmallDessertsFactory getInstance() {
		if(instance == null) {
			instance = new SmallDessertsFactory();
		}
		return instance;
	}

	@Override
	public Cake makeCake() {
		Cake cake = new ChocolateCake();
		return cake;
	}

	@Override
	public Coffee makeCoffee() {
		Coffee coffee = new Latte();
		return coffee;
	}

	@Override
	public Tea makeTea() {
		Tea tea = new GreenTea();
		return tea;
	}

}
