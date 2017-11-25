package factorySimple;

public class AKawaTest {
	
	public static void main(String[] args) {
		
		KawaFactory factory = new KawaFactory();
		Kawiarnia kawiarnia = new Kawiarnia(factory);		
	
		Kawa kawa1 = kawiarnia.zamowKawe("esp");
		Kawa kawa2 = kawiarnia.zamowKawe("cap");
		Kawa kawa3 = kawiarnia.zamowKawe("lat");
	}
}