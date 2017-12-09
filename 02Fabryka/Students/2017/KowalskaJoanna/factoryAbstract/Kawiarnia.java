package factoryAbstract;

public abstract class Kawiarnia {
	
	protected abstract Kawa przygotujKawa(String item);
 
	public Kawa zamowKawa(String type) {
		Kawa kawa = przygotujKawa(type);
 
		kawa.cena();
		kawa.wielkosc();
		kawa.ileKawy();
		kawa.ileMleka();
		kawa.przygotuj();
				
		return kawa;
	}
}
