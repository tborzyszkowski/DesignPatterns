package mbreza.dinner;

public class Dinner implements Cloneable{
    private FirstCourse firstCourse;
    private MainCourse mainCourse;
    private String dessert;

    public Dinner(FirstCourse firstCourse, MainCourse mainCourse, String dessert) {
        this.firstCourse = firstCourse;
        this.mainCourse = mainCourse;
        this.dessert = dessert;
    }

    public FirstCourse getFirstCourse() {
        return firstCourse;
    }

    public void setFirstCourse(FirstCourse firstCourse) {
        this.firstCourse = firstCourse;
    }

    public MainCourse getMainCourse() {
        return mainCourse;
    }

    public void setMainCourse(MainCourse mainCourse) {
        this.mainCourse = mainCourse;
    }

    public String getDessert() {
        return dessert;
    }

    public void setDessert(String dessert) {
        this.dessert = dessert;
    }

    @Override
    public Object clone() throws CloneNotSupportedException{
        Dinner copyDinner = (Dinner) super.clone();
        copyDinner.firstCourse = (FirstCourse) firstCourse.clone();
        copyDinner.mainCourse = (MainCourse) mainCourse.clone();
        return copyDinner;
    }

    public Object shallowCopy() throws CloneNotSupportedException{
        Dinner copyDinner = (Dinner) super.clone();
        return copyDinner;
    }
}