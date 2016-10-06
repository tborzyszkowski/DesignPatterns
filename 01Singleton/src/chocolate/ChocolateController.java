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
		//   Czy istnieje mo¿liwoœæ by dwa w¹tki wykonuj¹ce  
		//        ChocolateBoiler.getInstance()
		//   otrzyma³y dwie ró¿ne instancje klasy ChocolateBoiler ?
		//   Je¿eli tak zaproponuj przeplot instrukcji metody getInstance, która 
		//   do tego doprowadzi.
	}
}
