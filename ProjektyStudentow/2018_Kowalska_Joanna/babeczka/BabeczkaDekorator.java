package babeczka;

public class BabeczkaDekorator extends Babeczka {

	Babeczka babeczka;
	static int liczbaBabeczek;
	static double cenaBabeczek;
	
	public BabeczkaDekorator(Babeczka babeczka) {
		this.babeczka = babeczka;
	}
	
	@Override
	void piecz() {
		babeczka.piecz();
		liczbaBabeczek++;
		cenaBabeczek+=3.89;
	}

	public static int getLiczbaBabeczek() {
		return liczbaBabeczek;
	}

	public static void setLiczbaBabeczek(int liczbaBabeczek) {
		BabeczkaDekorator.liczbaBabeczek = liczbaBabeczek;
	}

	public static double getCenaBabeczek() {
		return cenaBabeczek;
	}

	public static void setCenaBabeczek(int cenaBabeczek) {
		BabeczkaDekorator.cenaBabeczek = cenaBabeczek;
	}
	
	@Override
	public String toString() {
		return babeczka.toString();
	}	
	
	@Override
	void przygotuj() {
		babeczka.przygotuj();
	}

	@Override
	public void registerObserver(Observer observer) {
		babeczka.registerObserver(observer);
	}
	
	@Override
	public void deleteObserver(Observer observer) {
		babeczka.deleteObserver(observer);
	}	

	@Override
	public void notifyObservers() {
		babeczka.notifyObservers();
	}
}
