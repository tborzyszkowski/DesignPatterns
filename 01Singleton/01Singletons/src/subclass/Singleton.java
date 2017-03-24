package subclass;

public class Singleton {
	protected static Singleton uniqueInstance;
 
	// other useful instance variables here
 
	protected Singleton() {
		System.out.println("Singleton()");
	}
 
	public static synchronized Singleton getInstance() {
		if (uniqueInstance == null) {
			System.out.println("getInstance(): First time getInstance was invoked!");
			uniqueInstance = new Singleton();
		}
		return uniqueInstance;
	}
 
	// other useful methods here
	public String toString(){
		return "" + this.getClass().getName();
	}
}
