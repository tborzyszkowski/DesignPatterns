package inheritance;

public class SingletonChildB extends SingletonParent implements ISingleton {
	static ISingleton instance;

	private SingletonChildB() {}

	public static ISingleton getInstance() {
		if(SingletonParent.instance == null) {
			if (instance == null) {
				instance = new SingletonChildB();
			}			
		}else {
			instance = SingletonParent.instance;
		}
		return instance;
	}

}
