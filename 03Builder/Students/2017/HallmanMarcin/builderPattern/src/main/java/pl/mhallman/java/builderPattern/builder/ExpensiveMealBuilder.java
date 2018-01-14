package pl.mhallman.java.builderPattern.builder;

public class ExpensiveMealBuilder extends MealBuilder {

    public void buildAppetizer() {
        meal.setAppetizer("Paluszki krabowe i kawior");
    }

    public void buildMainCourse() {
        meal.setMainCourse("Stek Ribeye");
    }

    public void buildDessert() {
        meal.setDessert("Specjalność szefa kuchni szefa kuchni");
    }

}
