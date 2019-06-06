package mbreza;

import mbreza.dinner.FirstCourse;
import mbreza.dinner.Meat;
import org.junit.Test;

import static org.junit.Assert.assertEquals;

public class FirstCourseTest {

    @Test
    public void firstCourseDeepCopyTest() throws CloneNotSupportedException {
        FirstCourse firstCourse = new FirstCourse("pomidorwa");
        FirstCourse cloneFirstCourse = (FirstCourse) firstCourse.clone();
        cloneFirstCourse.setSoup("grzybowa");

        assertEquals(cloneFirstCourse.getSoup(), "grzybowa");
        assertEquals(firstCourse.getSoup(), "pomidorwa");
    }
}
