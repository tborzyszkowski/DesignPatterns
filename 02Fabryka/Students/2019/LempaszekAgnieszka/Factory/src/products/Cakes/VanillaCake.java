package products.Cakes;

import products.Cake;
import products.Size;
import products.Taste;

public class VanillaCake extends Cake {
	
	public VanillaCake() {
		size =  Size.LARGE;
		taste = Taste.VANILLA;
		price = 16;
		name = "Sweet Time";
	}
	
}
