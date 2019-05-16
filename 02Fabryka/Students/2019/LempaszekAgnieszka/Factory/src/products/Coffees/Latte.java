package products.Coffees;

import products.Coffee;
import products.Size;
import products.Taste;

public class Latte extends Coffee {

	public Latte() {
		size = Size.SMALL;
		taste = Taste.VANILLA;
		price = 15;
		name = "Vanilla Sky";
	}
	
}
