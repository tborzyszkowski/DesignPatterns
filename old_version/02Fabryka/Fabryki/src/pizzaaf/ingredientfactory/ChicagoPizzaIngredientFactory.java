package pizzaaf.ingredientfactory;

import pizzaaf.ingredients.cheese.Cheese;
import pizzaaf.ingredients.cheese.MozzarellaCheese;
import pizzaaf.ingredients.clams.Clams;
import pizzaaf.ingredients.clams.FrozenClams;
import pizzaaf.ingredients.dough.Dough;
import pizzaaf.ingredients.dough.ThickCrustDough;
import pizzaaf.ingredients.pepperoni.Pepperoni;
import pizzaaf.ingredients.pepperoni.SlicedPepperoni;
import pizzaaf.ingredients.sauce.PlumTomatoSauce;
import pizzaaf.ingredients.sauce.Sauce;
import pizzaaf.ingredients.veggies.BlackOlives;
import pizzaaf.ingredients.veggies.Eggplant;
import pizzaaf.ingredients.veggies.Spinach;
import pizzaaf.ingredients.veggies.Veggies;

public class ChicagoPizzaIngredientFactory 
	implements PizzaIngredientFactory 
{

	public Dough createDough() {
		return new ThickCrustDough();
	}

	public Sauce createSauce() {
		return new PlumTomatoSauce();
	}

	public Cheese createCheese() {
		return new MozzarellaCheese();
	}

	public Veggies[] createVeggies() {
		Veggies veggies[] = { new BlackOlives(), 
		                      new Spinach(), 
		                      new Eggplant() };
		return veggies;
	}

	public Pepperoni createPepperoni() {
		return new SlicedPepperoni();
	}

	public Clams createClam() {
		return new FrozenClams();
	}
}
