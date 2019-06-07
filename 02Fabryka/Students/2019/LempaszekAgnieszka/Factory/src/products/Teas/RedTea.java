package products.Teas;

import products.Tea;
import products.Size;
import products.Taste;

public class RedTea extends Tea {
	
	public RedTea() {
		size = Size.SMALL;
		taste = Taste.NATURAL;
		price = 13;
		name = "Lazy Friday";
	}

}
