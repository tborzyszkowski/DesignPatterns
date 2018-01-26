package babeczka;

import java.util.ArrayList;
import java.util.Iterator;

public class Forma extends Babeczka {
	ArrayList zamowienie = new ArrayList();
	
	public void dodaj(Babeczka babeczka) {
		zamowienie.add(babeczka);
	}
	
	@Override
	public void piecz() {
		Iterator iterator = zamowienie.iterator();
		while (iterator.hasNext()) {
			Babeczka babeczka = (Babeczka)iterator.next();
			babeczka.piecz();
		}
	}

	@Override
	public String toString() {
		return "Forma z babeczkami";
	}

	@Override
	void przygotuj() {
	}

	@Override
	public void registerObserver(Observer observer) {
		Iterator iterator = zamowienie.iterator();
		while (iterator.hasNext()) {
			Babeczka babeczka = (Babeczka)iterator.next();
			babeczka.registerObserver(observer);
		}
	}
	
	@Override
	public void deleteObserver(Observer observer) {
		Iterator iterator = zamowienie.iterator();
		while (iterator.hasNext()) {
			Babeczka babeczka = (Babeczka)iterator.next();
			babeczka.deleteObserver(observer);
		}
	}	

	@Override
	public void notifyObservers() {
	}	
}
