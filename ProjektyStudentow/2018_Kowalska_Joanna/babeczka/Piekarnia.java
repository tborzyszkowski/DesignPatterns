package babeczka;

public abstract class Piekarnia {
	
	protected abstract Babeczka przygotujBabeczka(String item);
 
	public Babeczka zamowBabeczka(String type) {
		Babeczka babeczka = przygotujBabeczka(type);
 
		babeczka.piecz();
		babeczka.przygotuj();
				
		return babeczka;
	}
}
