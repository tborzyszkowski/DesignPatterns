package pl.kacprzak.BillPughSingleton;


public class BillPughSingleton {
	
	

	private BillPughSingleton() {
		
		System.out.println("New singleton is creating in thread : " + Thread.currentThread().getName());
	}

	private static class SingletonHolder {

		static final BillPughSingleton INSTANCE = new BillPughSingleton();

	}

	public static BillPughSingleton getInstance() {
		return SingletonHolder.INSTANCE;
	}

}
