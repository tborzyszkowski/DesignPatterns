package singleton;

public class Singleton {

	private static Singleton instance;

	protected Singleton() {
	}

	public static Singleton getInstance() {
		if (instance == null) {
			instance = new Singleton();
		}
		return instance;
	}

}
