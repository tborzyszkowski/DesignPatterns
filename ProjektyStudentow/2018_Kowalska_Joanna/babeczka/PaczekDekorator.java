package babeczka;

public class PaczekDekorator extends Babeczka {
	Babeczka babeczka;
	static int liczbaPaczkow;
	static double cenaPaczkow;
	
	public PaczekDekorator(Babeczka babeczka) {
		this.babeczka = babeczka;
	}
	
	@Override
	void piecz() {
		babeczka.piecz();
		liczbaPaczkow++;
		cenaPaczkow+=2.89;
	}

	public static int getLiczbaPaczkow() {
		return liczbaPaczkow;
	}

	public static void setLiczbaPaczkow(int liczbaPaczkow) {
		PaczekDekorator.liczbaPaczkow = liczbaPaczkow;
	}

	public static double getCenaPaczkow() {
		return cenaPaczkow;
	}

	public static void setCenaPaczkow(int cenaPaczkow) {
		PaczekDekorator.cenaPaczkow = cenaPaczkow;
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
