package runtimeImplementation;

public class RuntimeImplThreads implements Runnable {

	private Thread t;
	private String threadName;

	public RuntimeImplThreads(String name) {
		threadName = name;
	}

	public void run() {

		RuntimeSingleton singleton =  RuntimeSingleton.getInstance();
	}

	public void start() {
		if (t == null) {
			t = new Thread(this, threadName);
			t.start();
		}
	}

}
