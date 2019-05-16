package mbreza;

import mbreza.dinner.Meat;
import org.junit.Test;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertTrue;

public class MeatTest {

    @Test
    public void meatDeepCopyTest() throws CloneNotSupportedException {
        Meat meat = new Meat("wieprzowina");
        Meat cloneMeat = (Meat) meat.clone();
        cloneMeat.setMeatType("wolowina");

        assertEquals(cloneMeat.getMeatType(), "wolowina");
        assertEquals(meat.getMeatType(), "wieprzowina");
    }

}
