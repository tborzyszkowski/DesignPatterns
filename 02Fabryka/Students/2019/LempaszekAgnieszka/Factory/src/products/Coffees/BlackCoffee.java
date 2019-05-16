package products.Coffees;

import products.Coffee;
import products.Size;
import products.Taste;

public class BlackCoffee extends Coffee {

	public BlackCoffee() {
		size = Size.SMALL;
		taste = Taste.NATURAL;
		price = 7;
		name = "Monday Morning";
	}
	
}
