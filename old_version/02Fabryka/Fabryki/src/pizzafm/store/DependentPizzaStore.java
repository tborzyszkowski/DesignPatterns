package pizzafm.store;

import pizzafm.pizza.Pizza;
import pizzafm.pizza.chicago.ChicagoStyleCheesePizza;
import pizzafm.pizza.chicago.ChicagoStyleClamPizza;
import pizzafm.pizza.chicago.ChicagoStylePepperoniPizza;
import pizzafm.pizza.chicago.ChicagoStyleVeggiePizza;
import pizzafm.pizza.newyork.NYStyleCheesePizza;
import pizzafm.pizza.newyork.NYStyleClamPizza;
import pizzafm.pizza.newyork.NYStylePepperoniPizza;
import pizzafm.pizza.newyork.NYStyleVeggiePizza;

public class DependentPizzaStore {
 
	public Pizza createPizza(String style, String type) {
		Pizza pizza = null;
		if (style.equals("NY")) {
			if (type.equals("cheese")) {
				pizza = new NYStyleCheesePizza();
			} else if (type.equals("veggie")) {
				pizza = new NYStyleVeggiePizza();
			} else if (type.equals("clam")) {
				pizza = new NYStyleClamPizza();
			} else if (type.equals("pepperoni")) {
				pizza = new NYStylePepperoniPizza();
			}
		} else if (style.equals("Chicago")) {
			if (type.equals("cheese")) {
				pizza = new ChicagoStyleCheesePizza();
			} else if (type.equals("veggie")) {
				pizza = new ChicagoStyleVeggiePizza();
			} else if (type.equals("clam")) {
				pizza = new ChicagoStyleClamPizza();
			} else if (type.equals("pepperoni")) {
				pizza = new ChicagoStylePepperoniPizza();
			}
		} else {
			System.out.println("Error: invalid type of pizza");
			return null;
		}
		pizza.prepare();
		pizza.bake();
		pizza.cut();
		pizza.box();
		return pizza;
	}
}
