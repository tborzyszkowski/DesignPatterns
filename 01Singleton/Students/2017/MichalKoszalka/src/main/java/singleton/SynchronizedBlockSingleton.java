package singleton;

public class SynchronizedBlockSingleton {

	private static SynchronizedBlockSingleton instance;

	protected SynchronizedBlockSingleton() {
	}

	public static SynchronizedBlockSingleton getInstance() {
		if (instance == null) {
			synchronized (SynchronizedBlockSingleton.class) {
				if (instance == null) {
					instance = new SynchronizedBlockSingleton();
				}
			}
		}
		return instance;
	}

}
