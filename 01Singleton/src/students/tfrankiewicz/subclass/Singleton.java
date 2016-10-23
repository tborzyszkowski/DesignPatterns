/*
* 166122 Tomasz Franckiewicz
* Resolved problem with serialization/deserialization the singleton.
*/

package students.tfrankiewicz.subclass;

public class Singleton implements java.io.Serializable {
	private static final long serialVersionUID = -4404021770659633934L;
	protected static Singleton uniqueInstance;
 
	protected Singleton() {
		System.out.println("Singleton()");
	}

	
	// readResolve is used for replacing the object read from the stream.
	// The only use I've ever seen for this is enforcing singletons; 
	// when an object is read, replace it with the singleton instance. 
	// This ensures that nobody can create another instance by serializing and deserializing the singleton.
	
	protected Object readResolve() {
	    return getInstance();
	}
	
	public static synchronized Singleton getInstance() {
		if (uniqueInstance == null) {
			System.out.println("getInstance(): First time getInstance was invoked!");
			uniqueInstance = new Singleton();
		}
		return uniqueInstance;
	}
 
	public String toString(){
		return "" + this.getClass().getName();
	}
}
