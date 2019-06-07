package factoryMethod;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

import factoryMethod.CakesShop;
import factoryMethod.CoffeeDrinksShop;
import factoryMethod.TeasShop;

import products.Cakes.RaspberryCake;
import products.Teas.GreenTea;
import products.Coffees.BlackCoffee;
import products.Product;

class FactoryMethodTest {
	
	private static CakesShop cakesShop;
	private static CoffeeDrinksShop coffeeDrinksShop;
	private static TeasShop teasShop;
	
	@BeforeAll
	public static void settingUp() {
		cakesShop = CakesShop.getInstance();
		coffeeDrinksShop = CoffeeDrinksShop.getInstance();
		teasShop = TeasShop.getInstance();
	}
	
	@Test
	public void checkCoffeeCreation() {
		Product coffee = coffeeDrinksShop.make("Black");
		assertTrue(coffee instanceof BlackCoffee);
	}
	
	@Test
	public void checkCakeCreation() {
		Product cake = cakesShop.make("RaspBerry");
		assertTrue(cake instanceof RaspberryCake);
	}
	
	@Test
	public void checkTeaCreation() {
		Product tea = teasShop.make("greeN");
		assertTrue(tea instanceof GreenTea);
	}
	
	@Test 
	public void checkNotExisting() {
		Product tea = teasShop.make("pink");
		Product cake = cakesShop.make("yellow");
		
		assertAll(
					() -> assertNull(tea),
					() -> assertNull(cake)
				);
	}
}
