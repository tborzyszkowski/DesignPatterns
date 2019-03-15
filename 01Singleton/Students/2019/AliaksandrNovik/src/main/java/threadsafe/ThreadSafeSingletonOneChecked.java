package threadsafe;

public class ThreadSafeSingletonOneChecked {
	private static ThreadSafeSingletonOneChecked instance;

	private ThreadSafeSingletonOneChecked() {}
	
	public static synchronized ThreadSafeSingletonOneChecked getInstance() {
		if(instance==null) {
				instance = new ThreadSafeSingletonOneChecked();
		}
		return instance;
	}
	
	public long fibonacci(int n) {
		if (n <= 1) return n;
        else return fibonacci(n-1) + fibonacci(n-2);
	}

}
