package products.Coffees;

import products.Coffee;
import products.Size;
import products.Taste;

public class Americano extends Coffee {

	public Americano() {
		size = Size.MEDIUM;
		taste = Taste.NATURAL;
		price = 15;
		name = "Vanilla Sky";
	}
	
}
