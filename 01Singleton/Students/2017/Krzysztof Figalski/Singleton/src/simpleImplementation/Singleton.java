package simpleImplementation;

public class Singleton {

	private static Singleton instance = null;
	private static int instanceCounter = 0;

	private Singleton() {
	};

	public static Singleton getInstance() {
		if (instance == null) {
			synchronized (Singleton.class) {
				instance = new Singleton();
				instanceCounter++;
			}
		}
		return instance;
	}

	public int getInstanceCounter() {
		return instanceCounter;
	}

}
