package mbreza;

import mbreza.dinner.Dinner;
import mbreza.dinner.FirstCourse;
import mbreza.dinner.MainCourse;
import mbreza.dinner.Meat;
import org.junit.Test;

import static org.junit.Assert.assertEquals;

public class DinnerTest {

    @Test
    public void dinnerDeepCopyTest() throws CloneNotSupportedException {
        Dinner dinner = new Dinner(
                new FirstCourse("pomidorowa"),
                new MainCourse(new Meat("wolowina"),"warzywna"),
                "lody");

        Dinner copyDinner = (Dinner) dinner.clone();

        copyDinner.setDessert("szarlotka");
        copyDinner.getFirstCourse().setSoup("barszcz");
        copyDinner.getMainCourse().getMeat().setMeatType("wieprzowina");
        copyDinner.getMainCourse().setSalad("grecka");

        assertEquals(copyDinner.getDessert(), "szarlotka");
        assertEquals(copyDinner.getFirstCourse().getSoup(), "barszcz");
        assertEquals(copyDinner.getMainCourse().getMeat().getMeatType(), "wieprzowina");
        assertEquals(copyDinner.getMainCourse().getSalad(), "grecka");

        assertEquals(dinner.getDessert(), "lody");
        assertEquals(dinner.getFirstCourse().getSoup(), "pomidorowa");
        assertEquals(dinner.getMainCourse().getMeat().getMeatType(), "wolowina");
        assertEquals(dinner.getMainCourse().getSalad(), "warzywna");
    }

    @Test
    public void dinnerShallowCopyTest() throws CloneNotSupportedException {
        Dinner dinner = new Dinner(
                new FirstCourse("pomidorowa"),
                new MainCourse(new Meat("wolowina"),"warzywna"),
                "lody");

        Dinner copyDinner = (Dinner) dinner.shallowCopy();

        copyDinner.setDessert("szarlotka");
        copyDinner.getFirstCourse().setSoup("barszcz");
        copyDinner.getMainCourse().getMeat().setMeatType("wieprzowina");
        copyDinner.getMainCourse().setSalad("grecka");

        assertEquals(copyDinner.getDessert(), "szarlotka");
        assertEquals(copyDinner.getFirstCourse().getSoup(), "barszcz");
        assertEquals(copyDinner.getMainCourse().getMeat().getMeatType(), "wieprzowina");
        assertEquals(copyDinner.getMainCourse().getSalad(), "grecka");

        assertEquals(dinner.getDessert(), "lody");
        assertEquals(dinner.getFirstCourse().getSoup(), "barszcz");
        assertEquals(dinner.getMainCourse().getMeat().getMeatType(), "wieprzowina");
        assertEquals(dinner.getMainCourse().getSalad(), "grecka");
    }
}
