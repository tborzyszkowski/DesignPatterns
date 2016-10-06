package dcl;

//
// Danger!  This implementation of Singleton not
// guaranteed to work prior to Java 5
//

public class Singleton {
	private volatile static Singleton uniqueInstance;
 
	private Singleton() {
		System.out.println("Singleton(): Initializing Instance");
	}
 
	// Lazy solution 
	// See more on Double-checked locking
	// https://en.wikipedia.org/wiki/Double-checked_locking
	public static Singleton getInstance() {
		if (uniqueInstance == null) {
			synchronized (Singleton.class) {
				if (uniqueInstance == null) {
					System.out.println("getInstance(): First time getInstance was invoked!");
					uniqueInstance = new Singleton();
				}
			}
		}
		return uniqueInstance;
	}
}
