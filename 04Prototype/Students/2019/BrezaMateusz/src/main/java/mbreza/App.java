package mbreza;

import mbreza.dinner.Dinner;
import mbreza.dinner.FirstCourse;
import mbreza.dinner.MainCourse;
import mbreza.dinner.Meat;

public class App 
{
    public static void main( String[] args ) throws CloneNotSupportedException {
        Dinner dinner = new Dinner(
                new FirstCourse("pomidorowa"),
                new MainCourse(new Meat("wolowina"),"warzywna"),
                "lody");

        //Dinner copyDinner = (Dinner) dinner.clone();
        Dinner copyDinner = (Dinner)dinner.shallowCopy();

        copyDinner.getFirstCourse().setSoup("grzybowa");

        System.out.println(dinner.getFirstCourse().getSoup());

        System.out.println(copyDinner.getFirstCourse().getSoup());
    }
}
