package subclass;

public class SingletonTestDrive {
	public static void main(String[] args) {
		Singleton foo = CoolerSingleton.getInstance();
		Singleton bar = HotterSingleton.getInstance();
		System.out.println(foo);
		System.out.println(bar);
		// Czy zadziała ??
		// System.out.println((CoolerSingleton)foo);
		// System.out.println((HotterSingleton)bar);
 	}
}
