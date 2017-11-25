package simpleImplementation;

public class SimpleImplThreads implements Runnable {

	private Thread t;
	private String threadName;

	public SimpleImplThreads(String name) {
		threadName = name;
	}

	public void run() {

		Singleton singleton = Singleton.getInstance();

//		if (singleton.getInstanceCounter() != 1) {
//			System.out.println(
//					"Licznik instancji dla w¹tku \" + this.threadName + \" jest równy \" + singleton.getInstanceCounter()");
//			System.exit(0);
//		}
	}

	public void start() {
		if (t == null) {
			t = new Thread(this, threadName);
			t.start();
		}
	}

}
