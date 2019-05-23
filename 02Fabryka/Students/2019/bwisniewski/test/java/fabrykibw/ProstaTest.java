package fabrykibw;

import static org.junit.Assert.assertEquals;

import org.junit.Before;
import org.junit.Test;

import proste.FabrykaFigur;
import proste.Figura;
import proste.FiguraType;

public class ProstaTest {
	
	FabrykaFigur fabryka;

	@Before
	public void setup() {
		fabryka = FabrykaFigur.createInstance();
	}
	
	@Test
	public void kwadratTest(){
		Figura kwadrat = fabryka.stworzFigure(FiguraType.Kwadrat);
		assertEquals(kwadrat.getType(), "Kwadrat");
				
	}
	@Test
	public void prostokatTest(){
		Figura prostokat = fabryka.stworzFigure(FiguraType.Prostokat);
		assertEquals(prostokat.getType(), "Prostokat");
				
	}
	@Test
    public void czasTest() {
        long start = System.currentTimeMillis();
        for(int i = 0 ; i<1000000000 ; i++){
        	fabryka.stworzFigure(FiguraType.Kwadrat);
        }
        long koniec = System.currentTimeMillis();
        System.out.println("Czas prostej: " + (koniec - start));
}
}
