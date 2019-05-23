package food_order;

import static org.junit.Assert.*;

import org.junit.Test;

public class DrinkTest {
	@Test
	public void drinkDeepTest() throws CloneNotSupportedException {

		Drink drink = new Drink("Kola");
		assertEquals(drink.getDrinkType(), "Kola");

		Drink cloneDrink = (Drink) drink.clone();
		cloneDrink.setDrinkType("Szprit");
		assertEquals(cloneDrink.getDrinkType(), "Szprit");

	}
}
