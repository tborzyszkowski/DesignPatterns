package singleton;

public class SynchronizedMethodSingleton {

	private static SynchronizedMethodSingleton instance;

	protected SynchronizedMethodSingleton() {
	}

	public static synchronized SynchronizedMethodSingleton getInstance() {
		if (instance == null) {
			instance = new SynchronizedMethodSingleton();
		}
		return instance;
	}

}
