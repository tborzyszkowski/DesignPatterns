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
		//   Czy istnieje mozliwosc by dwa watki wykonujace  
		//        ChocolateBoiler.getInstance()
		//   otrzymaly dwie rozne instancje klasy ChocolateBoiler ?
		//   Jezeli tak zaproponuj przeplot instrukcji metody getInstance, ktora 
		//   do tego doprowadzi.
	}
}
