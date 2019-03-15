package inheritance;

public class SingletonParent implements ISingleton {

	protected static ISingleton instance;

	protected SingletonParent() {
	}

	public static ISingleton getInstance() {
		if (SingletonChildA.instance == null && SingletonChildB.instance == null) {
			if (instance == null) {
				instance = new SingletonParent();
			}
		} else if (SingletonChildA.instance != null) {
			instance = SingletonChildA.instance;
		} else if (SingletonChildB.instance != null) {
			instance = SingletonChildB.instance;
		}
		return instance;
	}

}
