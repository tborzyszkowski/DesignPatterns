package mbreza;

import mbreza.Abstract.BatmanFactory;
import mbreza.Abstract.IronManFactory;
import mbreza.Abstract.PopCulture;
import org.junit.Before;
import org.junit.Test;
import static org.junit.Assert.assertEquals;

public class AbstractTest {

    PopCulture ironMan;
    PopCulture batman;

    @Before
    public void setup(){
        ironMan = new PopCulture(IronManFactory.createInstance());
        batman = new PopCulture(BatmanFactory.createInstance());
    }

    @Test
    public void ironManTest() {
        assertEquals(ironMan.getComic().getType(), "IronMan komiks");
        assertEquals(ironMan.getMovie().getType(), "Ironman film");
    }

    @Test
    public void batmanTest() {
        assertEquals(batman.getComic().getType(), "Batman komiks");
        assertEquals(batman.getMovie().getType(), "Batman film");
    }

    @Test
    public void timeTest() {
        long start = System.currentTimeMillis();
        for(int i = 0 ; i<1000000 ; i++){
            batman.getComic();
        }
        long end = System.currentTimeMillis();
        System.out.println("Abstract time: " + (end - start));
    }
}
