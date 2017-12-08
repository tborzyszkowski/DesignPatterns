package pl.mhallman.java.builderPattern.builder;

public class StandardMealBuilder extends MealBuilder {

    public void buildAppetizer() {
        meal.setAppetizer("Nachosy z sosem");
    }

    public void buildMainCourse() {
        meal.setMainCourse("Włoska pizza i krążki cebulowa");
    }

    public void buildDessert() {
        meal.setDessert("Tiramisu");
    }

}
