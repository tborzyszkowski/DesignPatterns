package food_order;

import static org.junit.Assert.*;

import org.junit.Test;

public class MainDishTest {
	
	@Test
	public void mainDishDeepTest() throws CloneNotSupportedException{
		
		MainDish mainDish = new MainDish("Margaretitta", new Drink("Hejnejken"));
		assertEquals(mainDish.getMainDish(), "Margaretitta");
		assertEquals(mainDish.getDrink().getDrinkType(), "Hejnejken");
		
		MainDish cloneMainDish = (MainDish) mainDish.clone();
		cloneMainDish.setMainDish("Capriczjoza");
		cloneMainDish.getDrink().setDrinkType("Oranzada");
		
		assertEquals(cloneMainDish.getMainDish(), "Capriczjoza");
		assertEquals(cloneMainDish.getDrink().getDrinkType(), "Oranzada");
	}

}
