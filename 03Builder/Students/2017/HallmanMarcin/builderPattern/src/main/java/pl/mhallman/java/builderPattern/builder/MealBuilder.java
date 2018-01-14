package pl.mhallman.java.builderPattern.builder;

import pl.mhallman.java.builderPattern.model.Meal;

public abstract class MealBuilder {

    protected Meal meal;

    public Meal getMeal() {
        return this.meal;
    }

    public void createNewMeal() {
        this.meal = new Meal();
    }

    public abstract void buildAppetizer();
    public abstract void buildMainCourse();
    public abstract void buildDessert();
}
