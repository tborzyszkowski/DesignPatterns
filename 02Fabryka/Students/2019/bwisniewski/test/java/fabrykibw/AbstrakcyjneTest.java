package fabrykibw;

import static org.junit.Assert.assertEquals;

import org.junit.Before;
import org.junit.Test;

import abstrakcyjna.ASoIaFFactory;
import abstrakcyjna.Fantasy;
import abstrakcyjna.LotRFactory;

public class AbstrakcyjneTest {

	Fantasy lotR;
    Fantasy aSoIaF;

    @Before
    public void setup(){
    	lotR = new Fantasy(LotRFactory.getInstance());
    	aSoIaF = new Fantasy(ASoIaFFactory.getInstance());
    }

    @Test
    public void lotRTest() {
        assertEquals(lotR.getBook().getType(), "LotRBook");
        assertEquals(lotR.getMovie().getType(), "LotRMovie");
    }

    @Test
    public void aSoIaFTest() {
        assertEquals(aSoIaF.getBook().getType(), "ASoIaFBook");
        assertEquals(aSoIaF.getMovie().getType(), "ASoIaFMovie");
    }

    @Test
    public void timeTest() {
        long start = System.currentTimeMillis();
        for(int i = 0 ; i<1000000 ; i++){
        	lotR.getBook();
        }
        long koniec = System.currentTimeMillis();
        System.out.println("Czas abstrakcyjnej: " + (koniec - start));
    }
}
