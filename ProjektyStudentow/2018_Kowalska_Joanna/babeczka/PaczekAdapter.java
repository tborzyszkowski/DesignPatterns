package babeczka;

public class PaczekAdapter extends Babeczka {

	Paczek paczek;
	Observable observable;
	
	public PaczekAdapter(Paczek paczek) {
		this.paczek = paczek;
		observable = new Observable(this);
	}
	
	@Override
	void piecz() {
		paczek.smaz();
		notifyObservers();
	}

	@Override
	public String toString() {
		return "pączek smażony, a nie upieczony";
	}
	
	@Override
	void przygotuj() {
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
