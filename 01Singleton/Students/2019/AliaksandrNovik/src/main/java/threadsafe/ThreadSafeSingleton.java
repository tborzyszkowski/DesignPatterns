package threadsafe;

public class ThreadSafeSingleton {

	private static ThreadSafeSingleton instance;

	private ThreadSafeSingleton() {}
	
	public static ThreadSafeSingleton getInstance() {
		if(instance==null) {
			synchronized (ThreadSafeSingleton.class) {
				instance = new ThreadSafeSingleton();
			}
		}
		return instance;
	}
	
	public long fibonacci(int n) {
		if (n <= 1) return n;
        else return fibonacci(n-1) + fibonacci(n-2);
	}

}
