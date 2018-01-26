package babeczka;

public abstract class BabeczkaObservable {
	public abstract void registerObserver(Observer observer);
	public abstract void deleteObserver(Observer observer);
	public abstract void notifyObservers();
}
