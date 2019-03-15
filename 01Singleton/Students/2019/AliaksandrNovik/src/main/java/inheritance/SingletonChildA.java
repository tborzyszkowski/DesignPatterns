package inheritance;

public class SingletonChildA extends SingletonParent implements ISingleton{

	static ISingleton instance;

	private SingletonChildA() {}

	public static ISingleton getInstance() {
		if(SingletonParent.instance == null) {
			if (instance == null) {
				instance = new SingletonChildA();
			}			
		}else if(SingletonChildB.instance != null && SingletonParent.instance == null){
			if (instance == null) {
				instance = new SingletonChildA();
			}			
		}else if(SingletonChildB.instance != null && SingletonParent.instance != null){
			if (instance == null) {
				instance = new SingletonChildA();
			}
		}else {
			instance = SingletonParent.instance;
		}
		return instance;
	}

}
