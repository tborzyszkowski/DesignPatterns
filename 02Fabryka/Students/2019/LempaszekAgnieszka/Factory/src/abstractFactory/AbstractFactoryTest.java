package abstractFactory;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

import abstractFactory.CheapDessertsFactory;
import abstractFactory.SmallDessertsFactory;
import abstractFactory.CoffeeShop;

import products.Size;
import products.Product;
import products.Cakes.CheeseCake;


public class AbstractFactoryTest {
	
	private static CoffeeShop cheapDessertsShop;
	private static CoffeeShop smallDessertsShop;
	
	@BeforeAll
	public static void settingUp() {
		cheapDessertsShop = new CoffeeShop(CheapDessertsFactory.getInstance());
		smallDessertsShop = new CoffeeShop(SmallDessertsFactory.getInstance());
	}
	
	@Test
	public void allProductsHaveSamePrice() {
		Product cake = cheapDessertsShop.makeCake();
		Product tea = cheapDessertsShop.makeTea();
		Product coffee = cheapDessertsShop.makeCoffee();
		
		assertAll(
					() -> assertEquals(7, cake.getPrice()),
					() -> assertEquals(7, tea.getPrice()),
					() -> assertEquals(7, coffee.getPrice())
				);
	}
	
	@Test
	public void allProductsAreSmall() {
		Product cake = smallDessertsShop.makeCake();
		Product tea = smallDessertsShop.makeTea();
		Product coffee = smallDessertsShop.makeCoffee();
		
		assertAll(
					() -> assertEquals(Size.SMALL, cake.getSize()),
					() -> assertEquals(Size.SMALL, tea.getSize()),
					() -> assertEquals(Size.SMALL, coffee.getSize())
				);
	}
	
	@Test
	public void cheapFactoryReturnsCheeseCake() {
		Product cake = cheapDessertsShop.makeCake();
		assertTrue(cake instanceof CheeseCake);
	}

}
