package threadsafe;

public class Singleton {
	private static Singleton uniqueInstance;
 
	// other useful instance variables here
 
	private Singleton() {}
 
	public static synchronized Singleton getInstance() {
		if (uniqueInstance == null) {
			uniqueInstance = new Singleton();
		}
		return uniqueInstance;
	}
 
	// other useful methods here
	
	// Zadanie: 
	//    Napisz kod korzystajacy z classic.Singleton oraz threadsafe.Singleton
	//    demonstrujacy problemy w korzystaniu przez niezalezne watki z klasycznej
	//    definicji. gęś
}
