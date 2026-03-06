package threadsafe;

public class Singleton {
	private static Singleton uniqueInstance;
 
	// other useful instance variables here
 
	private Singleton() {}
 
	// threadsafe but expensive (while?)
	public static synchronized Singleton getInstance() {
		if (uniqueInstance == null) {
			uniqueInstance = new Singleton();
		}
		return uniqueInstance;
	}
 
	// other useful methods here
	
	// Zadanie: 
	//    Napisz kod korzystający z classic.Singleton oraz threadsafe.Singleton
	//    demonstrujący problemy w korzystaniu przez niezależne wątki z klasycznej
	//    definicji. 
}
