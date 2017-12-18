package builder.buildervsfactory.sandwich.builder;

import java.util.Arrays;

import org.junit.jupiter.api.Test;

import builder.buildervsfactory.sandwich.enums.Bread;
import builder.buildervsfactory.sandwich.enums.Cheese;
import builder.buildervsfactory.sandwich.enums.Meat;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertTrue;

class SandwichBuilderTest {

	@Test
	public void test() {
		Sandwich sandwich = new Sandwich.SandwichBuilder().withBread(Bread.RYE).withCheese(Cheese.MOZZARELLA).withMeat(
				Meat.CHICKEN).withVegetables(Arrays.asList("tomato", "cucumber")).build();

		assertEquals(sandwich.getBread(), Bread.RYE);
		assertEquals(sandwich.getCheese(), Cheese.MOZZARELLA);
		assertEquals(sandwich.getMeat(), Meat.CHICKEN);
		assertTrue(sandwich.getVegetables().contains("tomato"));
		assertTrue(sandwich.getVegetables().contains("cucumber"));
	}

}