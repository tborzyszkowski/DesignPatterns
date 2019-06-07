package simpleFactory;

import static org.junit.jupiter.api.Assertions.*;
import static org.junit.jupiter.api.Assertions.assertTrue;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

import products.Cakes.RaspberryCake;
import products.Teas.GreenTea;
import products.Product;

class SimpleFactoryTest {
	
	private static CoffeeShop coffeeShop;
	
	@BeforeAll
	public static void settingUp() {
		coffeeShop = new CoffeeShop();
	}

	@Test
	public void isRaspberryCakeCreated() {
		Product cake = coffeeShop.orderCake("raspberry");
		assertTrue(cake instanceof RaspberryCake);
	}
	
	@Test
	public void isGreenTea() {
		Product tea = coffeeShop.orderTea("green");
		assertTrue(tea instanceof GreenTea);
	}
	
	@Test
	public void createNonExisted() {
		Product tea = coffeeShop.orderTea("pink");
		assertNull(tea);
	}
 
}
