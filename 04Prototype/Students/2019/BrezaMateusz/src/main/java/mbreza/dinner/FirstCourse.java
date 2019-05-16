package mbreza.dinner;

public class FirstCourse implements Cloneable{
    private String soup;

    public FirstCourse(String soup) {
        this.soup = soup;
    }

    public String getSoup() {
        return soup;
    }

    public void setSoup(String soup) {
        this.soup = soup;
    }

    @Override
    public Object clone() throws CloneNotSupportedException{
        FirstCourse copyfirstCourse = (FirstCourse) super.clone();
        return copyfirstCourse;
    }
}
