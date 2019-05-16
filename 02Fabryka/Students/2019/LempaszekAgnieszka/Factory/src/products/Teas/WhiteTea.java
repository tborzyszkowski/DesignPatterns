package products.Teas;

import products.Tea;
import products.Size;
import products.Taste;

public class WhiteTea extends Tea {
	
	public WhiteTea() {
		size = Size.SMALL;
		taste = Taste.NATURAL;
		price = 10;
		name = "Sunny Morning";
	}

}
