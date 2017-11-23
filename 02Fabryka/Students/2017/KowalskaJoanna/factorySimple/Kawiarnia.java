package factorySimple;

public class Kawiarnia {
	KawaFactory factory;
	 
	public Kawiarnia(KawaFactory factory) { 
		this.factory = factory;
	}
 
	public Kawa zamowKawe(String type) {
		Kawa kawa;
 
		kawa = factory.przygotujKawa(type);
 
		kawa.cena();
		kawa.wielkosc();
		kawa.ileKawy();
		kawa.ileMleka();

		return kawa;
	}
}
