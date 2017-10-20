package pizzaaf.ingredientfactory;

import pizzaaf.ingredients.cheese.Cheese;
import pizzaaf.ingredients.cheese.ReggianoCheese;
import pizzaaf.ingredients.clams.Clams;
import pizzaaf.ingredients.clams.FreshClams;
import pizzaaf.ingredients.dough.Dough;
import pizzaaf.ingredients.dough.ThinCrustDough;
import pizzaaf.ingredients.pepperoni.Pepperoni;
import pizzaaf.ingredients.pepperoni.SlicedPepperoni;
import pizzaaf.ingredients.sauce.MarinaraSauce;
import pizzaaf.ingredients.sauce.Sauce;
import pizzaaf.ingredients.veggies.Garlic;
import pizzaaf.ingredients.veggies.Mushroom;
import pizzaaf.ingredients.veggies.Onion;
import pizzaaf.ingredients.veggies.RedPepper;
import pizzaaf.ingredients.veggies.Veggies;

public class NYPizzaIngredientFactory implements PizzaIngredientFactory {
 
	public Dough createDough() {
		return new ThinCrustDough();
	}
 
	public Sauce createSauce() {
		return new MarinaraSauce();
	}
 
	public Cheese createCheese() {
		return new ReggianoCheese();
	}
 
	public Veggies[] createVeggies() {
		Veggies veggies[] = { new Garlic(), new Onion(), new Mushroom(), new RedPepper() };
		return veggies;
	}
 
	public Pepperoni createPepperoni() {
		return new SlicedPepperoni();
	}

	public Clams createClam() {
		return new FreshClams();
	}
}
