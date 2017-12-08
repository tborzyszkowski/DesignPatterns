package pl.mhallman.java.builderPattern.builder;

public class CheapMealBuilder extends MealBuilder {

    public void buildAppetizer() {
        meal.setAppetizer("Kabanosy");
    }

    public void buildMainCourse() {
        meal.setMainCourse("Schabowy z ziemniakami i surówką");
    }

    public void buildDessert() {
        meal.setDessert("Sernik");
    }

}
