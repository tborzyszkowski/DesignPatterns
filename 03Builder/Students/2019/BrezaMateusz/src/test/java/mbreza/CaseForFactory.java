package mbreza;

import mbreza.caseForFactory.ErgonomicFactory;
import mbreza.caseForFactory.NormalFactory;
import mbreza.caseForFactory.Worksite;
import org.junit.Before;
import org.junit.Test;

import static junit.framework.TestCase.assertEquals;

public class CaseForFactory {

    Worksite normal;
    Worksite ergonomic;

    @Before
    public void setup(){
        normal = new Worksite(NormalFactory.createInstance());
        ergonomic = new Worksite(ErgonomicFactory.createInstance());
    }

    @Test
    public void normalTest() {
        assertEquals(normal.getChair().getType(), "normal chair");
        assertEquals(normal.getDesk().getType(), "normal desk");
    }

    @Test
    public void ergonomicTest() {
        assertEquals(ergonomic.getChair().getType(), "ergonomic chair");
        assertEquals(ergonomic.getDesk().getType(), "ergonomic desk");
    }

}
