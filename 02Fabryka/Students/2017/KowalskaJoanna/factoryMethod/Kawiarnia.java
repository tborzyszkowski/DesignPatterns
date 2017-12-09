package factoryMethod;

public abstract class Kawiarnia {	
	abstract Kawa przygotujKawa(String type);
	
	public Kawa zamowKawa(String type) {
		Kawa kawa = przygotujKawa(type);
		
		kawa.przygotuj();
		
		return kawa;
	}
}
