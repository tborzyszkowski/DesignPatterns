package babeczka;

public class BabeczkaJagodowa extends Babeczka {

	PiekarniaFactory factory;
	Observable observable;
	 
	public BabeczkaJagodowa(PiekarniaFactory factory) {
		this.factory = factory;
		observable = new Observable(this);
	}
	
	@Override
	void przygotuj() {
		ksztalt = factory.przygotujKsztalt();
	}	
	
	@Override
	public void piecz() {
		System.out.println("KUCHARZ:\nBabeczka jagodowa upieczona!");
		notifyObservers();
	}
	
	@Override
	public String toString() {
		return "babeczka jagodowa, kształt: " + ksztalt;
	}	
	
	@Override
	public void registerObserver(Observer observer) {
		observable.registerObserver(observer);
	}
	
	@Override
	public void deleteObserver(Observer observer) {
		observable.deleteObserver(observer);
	}	

	@Override
	public void notifyObservers() {
		observable.notifyObservers();
	}	
}
