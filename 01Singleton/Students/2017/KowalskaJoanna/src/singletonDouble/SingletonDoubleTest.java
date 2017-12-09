package singletonDouble;
//double checked locking

public class SingletonDoubleTest {
	public static void main(String[] args) {

		Thread thread1 = new Thread(new Runnable() {
			public void run() {
				SingletonDouble object = SingletonDouble.pobierzInstancje();
			}
		});
		
		Thread thread2 = new Thread(new Runnable() {
			public void run() {
				SingletonDouble object = SingletonDouble.pobierzInstancje();
			}
		});
		
		Thread thread3 = new Thread(new Runnable() {
			public void run() {
				SingletonDouble object = SingletonDouble.pobierzInstancje();
			}
		});
		
		System.out.println("Tworzymy instancję:");
		thread1.start();
		thread2.start();
		thread3.start();
	}
}
