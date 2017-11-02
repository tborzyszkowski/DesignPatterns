package pl.kacprzak.NotSafeThreadSingleton;

public class Test {

	public static void main(String[] args) {

		for (int i = 0; i < 50; i++) {

			new Thread(new Test.MyThread()).start();

		}
	}

	static class MyThread implements Runnable {

		public void run() {

			NotSafeThreadSingleton.getInstance();

		}

	}
}
