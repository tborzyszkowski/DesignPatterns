package simpleFactory;

import products.Cake;
import products.Tea;
import products.Coffee;

public class CoffeeShop {

	private  SimpleFactory sFactory;
	
	public CoffeeShop() {
		this.sFactory = SimpleFactory.getInstance();
	}
	
	public Cake orderCake(String type) {
		Cake cake = sFactory.makeCake(type);
		if(cake == null) {
			return null;
		}
		
		cake.make();
		cake.addGlaze();
		cake.eat();
		
		return cake;
	}
	
	public Tea orderTea(String type) {
		Tea tea = sFactory.makeTea(type);
		if(tea == null) {
			return null;
		}
		
		tea.make();
		tea.addLemon();
		tea.drink();
		
		return tea;
	}
	
	public Coffee orderCoffee(String type) {
		Coffee coffee = sFactory.makeCoffee(type);
		if(coffee == null) {
			return null;
		}
		
		coffee.make();
		coffee.addMilk();
		coffee.drink();
		
		return coffee;
	}
	
}
