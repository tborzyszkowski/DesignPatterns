package singletonSynch;
//synchronized/multithreaded

public class SingletonSynchTest {
	public static void main(String[] args) {

		Thread thread1 = new Thread(new Runnable() {
			public void run() {
				SingletonSynch object = SingletonSynch.pobierzInstancje();
			}
		});
		
		Thread thread2 = new Thread(new Runnable() {
			public void run() {
				SingletonSynch object = SingletonSynch.pobierzInstancje();
			}
		});
		
		Thread thread3 = new Thread(new Runnable() {
			public void run() {
				SingletonSynch object = SingletonSynch.pobierzInstancje();
			}
		});
		
		System.out.println("Tworzymy instancję:");
		thread1.start();
		thread2.start();
		thread3.start();
	}
}
