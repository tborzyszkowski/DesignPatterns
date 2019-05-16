package products.Coffees;

import products.Coffee;
import products.Size;
import products.Taste;

public class Espresso extends Coffee {

	public Espresso() {
		size = Size.SMALL;
		taste = Taste.NATURAL;
		price = 9;
		name = "Monday Morning";
	}
	
}
