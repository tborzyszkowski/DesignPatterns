package pl.mhallman.java.builderPattern;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import pl.mhallman.java.builderPattern.builder.CheapMealBuilder;
import pl.mhallman.java.builderPattern.builder.ExpensiveMealBuilder;
import pl.mhallman.java.builderPattern.builder.MealBuilder;
import pl.mhallman.java.builderPattern.director.Waiter;
import pl.mhallman.java.builderPattern.model.Meal;

public class AppTest
{

    Waiter waiter;

    @Before
    public void setUp() {
        waiter = new Waiter();
    }

    @Test
    public void testMealBuilder() {
        MealBuilder expensiveMealBuilder = new ExpensiveMealBuilder();
        MealBuilder cheapMealBuilder = new CheapMealBuilder();

        Meal expensiveMeal;
        Meal cheapMeal;

        waiter.setMealBuilder(expensiveMealBuilder);
        waiter.constructMeal();
        expensiveMeal = waiter.getMeal();

        waiter.setMealBuilder(cheapMealBuilder);
        waiter.constructMeal();
        cheapMeal = waiter.getMeal();

        Assert.assertNotEquals(expensiveMeal.getAppetizer(), cheapMeal.getAppetizer());

    }
}
