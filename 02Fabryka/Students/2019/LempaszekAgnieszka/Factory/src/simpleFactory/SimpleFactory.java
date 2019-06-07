package simpleFactory;

import products.Coffee;
import products.Coffees.*;
import products.Tea;
import products.Teas.*;
import products.Cake;
import products.Cakes.*;

public class SimpleFactory {

	private static SimpleFactory instance;
	
	private SimpleFactory() {}
	
	public static SimpleFactory getInstance() {
		if(instance == null) {
			instance = new SimpleFactory();
		}
		return instance;
	}
	
	public Tea makeTea(String type) {
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
	
	public Coffee makeCoffee(String type) {
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
	
	public Cake makeCake(String type) {
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
