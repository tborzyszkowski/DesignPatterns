package pl.mhallman.java.builderPattern.director;

import pl.mhallman.java.builderPattern.builder.MealBuilder;
import pl.mhallman.java.builderPattern.model.Meal;

public class Waiter {

    private MealBuilder mealBuilder;

    public void setMealBuilder(MealBuilder builder) {
        this.mealBuilder = builder;
    }

    public Meal getMeal() {
        return mealBuilder.getMeal();
    }

    public void constructMeal() {
        mealBuilder.createNewMeal();
        mealBuilder.buildAppetizer();
        mealBuilder.buildMainCourse();
        mealBuilder.buildDessert();
    }

}
