package pizzafm.store;

import pizzafm.pizza.Pizza;
import pizzafm.pizza.chicago.ChicagoStyleCheesePizza;
import pizzafm.pizza.chicago.ChicagoStyleClamPizza;
import pizzafm.pizza.chicago.ChicagoStylePepperoniPizza;
import pizzafm.pizza.chicago.ChicagoStyleVeggiePizza;

public class ChicagoPizzaStore extends PizzaStore {

	Pizza createPizza(String item) {
        	if (item.equals("cheese")) {
            		return new ChicagoStyleCheesePizza();
        	} else if (item.equals("veggie")) {
        	    	return new ChicagoStyleVeggiePizza();
        	} else if (item.equals("clam")) {
        	    	return new ChicagoStyleClamPizza();
        	} else if (item.equals("pepperoni")) {
            		return new ChicagoStylePepperoniPizza();
        	} else return null;
	}
}
