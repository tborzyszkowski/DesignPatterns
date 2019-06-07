package products.Teas;

import products.Tea;
import products.Size;
import products.Taste;

public class GreenTea extends Tea {
	
	public GreenTea() {
		size = Size.SMALL;
		taste = Taste.NATURAL;
		price = 11;
		name = "Lazy Sunday";
	}

}
