package builder.buildervsfactory.sandwich.factory;

import java.util.Arrays;

import org.junit.jupiter.api.Test;

import builder.buildervsfactory.sandwich.common.SandwichBase;
import builder.buildervsfactory.sandwich.enums.Bread;
import builder.buildervsfactory.sandwich.enums.Cheese;
import builder.buildervsfactory.sandwich.enums.Meat;

import static org.junit.jupiter.api.Assertions.*;

class SandwichMakerTest {

	@Test
	public void makeSandwich() {
		SandwichMaker sandwichMaker = new SandwichMaker();

		SandwichBase sandwichA = sandwichMaker.makeSandwich(new SandwichAFactory());
		assertEquals(sandwichA.getBread(), Bread.RYE);
		assertEquals(sandwichA.getCheese(), Cheese.GOUDA);
		assertEquals(sandwichA.getMeat(), Meat.BEEF);
		assertTrue(sandwichA.getVegetables().contains("cucumber"));
		assertTrue(sandwichA.getVegetables().contains("olives"));

		SandwichBase sandwichB = sandwichMaker.makeSandwich(new SandwichBFactory());
		assertEquals(sandwichB.getBread(), Bread.WHOLE_GRAIN);
		assertEquals(sandwichB.getCheese(), Cheese.MOZZARELLA);
		assertEquals(sandwichB.getMeat(), Meat.CHICKEN);
		assertTrue(sandwichB.getVegetables().contains("tomato"));
		assertTrue(sandwichB.getVegetables().contains("lettuce"));
	}


}