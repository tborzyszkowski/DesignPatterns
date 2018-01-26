package babeczka;

import java.util.ArrayList;
import java.util.Iterator;

public class Observable extends BabeczkaObservable {
	ArrayList observers = new ArrayList();
	BabeczkaObservable babeczka;
	
	public Observable(BabeczkaObservable babeczka) {
		this.babeczka = babeczka;
	}
	
	@Override
	public void registerObserver(Observer observer) {
		observers.add(observer);
	}
	
	@Override
	public void deleteObserver(Observer observer) {
		int i = observers.indexOf(observer);
		if(i >= 0) {
			observers.remove(i);
		}
	}
	
	@Override
	public void notifyObservers() {
		Iterator iterator = observers.iterator();
		while (iterator.hasNext()) {
			Observer observer = (Observer)iterator.next();
			observer.update(babeczka);
		}
	}
	
	public Iterator getObservers() {
		return observers.iterator();
	}	
}
