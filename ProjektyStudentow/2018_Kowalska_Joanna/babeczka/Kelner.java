package babeczka;

public class Kelner implements Observer {
	@Override
	public void update(BabeczkaObservable babeczka) {
		System.out.println("KELNER:\nKucharz donosi, że " + babeczka + " już się upiekła.");
	}

	public String toString() {
		return "Kelner";
	}
}
