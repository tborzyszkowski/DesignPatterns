package subclass;

public class CoolerSingleton extends Singleton {
	// useful instance variables here
	protected static Singleton uniqueInstance;
 
	private CoolerSingleton() {
		super();
		System.out.println("CoolerSingleton()");
	}
 
	// useful methods here
}
