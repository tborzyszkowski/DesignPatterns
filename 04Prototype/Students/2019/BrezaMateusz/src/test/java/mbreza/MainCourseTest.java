package mbreza;

import mbreza.dinner.FirstCourse;
import mbreza.dinner.MainCourse;
import mbreza.dinner.Meat;
import org.junit.Test;

import static org.junit.Assert.assertEquals;

public class MainCourseTest {

    @Test
    public void mainCourseDeepCopyTest() throws CloneNotSupportedException {
        MainCourse mainCourse = new MainCourse(new Meat("wolowina"), "cezar");
        MainCourse cloneMainCourse = (MainCourse) mainCourse.clone();
        cloneMainCourse.getMeat().setMeatType("wieprzowina");
        cloneMainCourse.setSalad("gyros");

        assertEquals(cloneMainCourse.getSalad(), "gyros");
        assertEquals(cloneMainCourse.getMeat().getMeatType(), "wieprzowina");

        assertEquals(mainCourse.getSalad(), "cezar");
        assertEquals(mainCourse.getMeat().getMeatType(), "wolowina");
    }

}
