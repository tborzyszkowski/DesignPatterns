package mbreza.dinner;

public class MainCourse implements Cloneable{
    private Meat meat;
    private String salad;

    public MainCourse(Meat meat, String salad) {
        this.meat = meat;
        this.salad = salad;
    }

    public Meat getMeat() {
        return meat;
    }

    public void setMeat(Meat meat) {
        this.meat = meat;
    }

    public String getSalad() {
        return salad;
    }

    public void setSalad(String salad) {
        this.salad = salad;
    }

    @Override
    public Object clone() throws CloneNotSupportedException{
        MainCourse copyMainCourse = (MainCourse) super.clone();
        copyMainCourse.meat = (Meat) meat.clone();
        return copyMainCourse;
    }
}
