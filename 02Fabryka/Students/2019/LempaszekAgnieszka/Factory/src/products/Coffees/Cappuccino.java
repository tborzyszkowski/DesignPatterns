package products.Coffees;

import products.Coffee;
import products.Size;
import products.Taste;

public class Cappuccino extends Coffee {

	public Cappuccino() {
		size = Size.SMALL;
		taste = Taste.CARMEL;
		price = 12;
		name = "Sweet Carmel";
	}
	
}
