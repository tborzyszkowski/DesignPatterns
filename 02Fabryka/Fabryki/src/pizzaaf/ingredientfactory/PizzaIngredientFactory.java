package pizzaaf.ingredientfactory;

import pizzaaf.ingredients.cheese.Cheese;
import pizzaaf.ingredients.clams.Clams;
import pizzaaf.ingredients.dough.Dough;
import pizzaaf.ingredients.pepperoni.Pepperoni;
import pizzaaf.ingredients.sauce.Sauce;
import pizzaaf.ingredients.veggies.Veggies;

public interface PizzaIngredientFactory {
 
	public Dough createDough();
	public Sauce createSauce();
	public Cheese createCheese();
	public Veggies[] createVeggies();
	public Pepperoni createPepperoni();
	public Clams createClam();
 
}
