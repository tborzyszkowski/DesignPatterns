package runtimeImplementation;

public class RuntimeSingleton {

	private static int instanceCounter = 0;
	private static final RuntimeSingleton instance = new RuntimeSingleton();

	protected RuntimeSingleton() {
	}

	public static RuntimeSingleton getInstance() {
		return instance;
	}

	public int getInstanceCounter() {
		return instanceCounter;
	}
}