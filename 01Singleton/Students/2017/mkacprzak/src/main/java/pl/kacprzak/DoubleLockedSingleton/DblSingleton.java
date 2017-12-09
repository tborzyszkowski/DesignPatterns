package pl.kacprzak.DoubleLockedSingleton;

public class DblSingleton {

	private static volatile DblSingleton singleton;

	private DblSingleton() {
		
		System.out.println("New singleton is creating in thread : " + Thread.currentThread().getName());
	}

	public static DblSingleton getInstance() {
		if (singleton == null)
			synchronized (DblSingleton.class) {
				if (singleton == null) {
					singleton = new DblSingleton();
				}

			}

		return singleton;
	}

}
