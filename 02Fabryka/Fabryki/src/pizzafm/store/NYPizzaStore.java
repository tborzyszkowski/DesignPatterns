package pizzafm.store;

import pizzafm.pizza.Pizza;
import pizzafm.pizza.newyork.NYStyleCheesePizza;
import pizzafm.pizza.newyork.NYStyleClamPizza;
import pizzafm.pizza.newyork.NYStylePepperoniPizza;
import pizzafm.pizza.newyork.NYStyleVeggiePizza;

public class NYPizzaStore extends PizzaStore {

	Pizza createPizza(String item) {
		if (item.equals("cheese")) {
			return new NYStyleCheesePizza();
		} else if (item.equals("veggie")) {
			return new NYStyleVeggiePizza();
		} else if (item.equals("clam")) {
			return new NYStyleClamPizza();
		} else if (item.equals("pepperoni")) {
			return new NYStylePepperoniPizza();
		} else return null;
	}
}
