package chocolate;
 
public class ChocolateController {
	public static void main(String args[]) {
		ChocolateBoiler boiler = ChocolateBoiler.getInstance();
		boiler.fill();
		boiler.boil();
		boiler.drain();

		// will return the existing instance
		ChocolateBoiler boiler2 = ChocolateBoiler.getInstance();
		System.out.println(boiler == boiler2);
		
		// Zadanie:
		//   Czy istnieje możliwość by dwa wątki wykonujące  
		//        ChocolateBoiler.getInstance()
		//   otrzymały dwie różne instancje klasy ChocolateBoiler ?
		//   Jeżeli tak zaproponuj przeplot instrukcji metody getInstance, która 
		//   do tego doprowadzi.
	}
}
