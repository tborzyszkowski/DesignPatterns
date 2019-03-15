package enumsingletone;

public class ThreadOne extends Thread {

	private final static int NUM = 20;
	private EnumSingletone instance;
	private int instanceHashCode;

	public ThreadOne() {
		instance = EnumSingletone.INSTANCE;
		instanceHashCode = instance.hashCode();
	}

	@Override
	public void run() {

		for (int i = 0; i < NUM; i++) {
			System.out.println(instance.fibonacci(i));
		}
	}

	public int getInstanceHashCode() {
		return instanceHashCode;
	}

}