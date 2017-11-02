package pl.kacprzak.NotSafeThreadSingleton;


public class NotSafeThreadSingleton {
	private static NotSafeThreadSingleton uniqueInstance;


	private NotSafeThreadSingleton() {
		System.out.println("New singleton is creating in thread : " + Thread.currentThread().getName());
	}

	public static NotSafeThreadSingleton getInstance() {
		if (uniqueInstance == null) {
			uniqueInstance = new NotSafeThreadSingleton();

		}
		return uniqueInstance;
	}

}