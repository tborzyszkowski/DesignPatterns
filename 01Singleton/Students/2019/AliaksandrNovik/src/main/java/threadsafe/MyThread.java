package threadsafe;

public class MyThread extends Thread {
	
	private ThreadSafeSingleton instance = null;

	private int x;
	
	public MyThread(int x) {
		this.x = x;
	}
	
	@Override
	public void run() {
        instance = ThreadSafeSingleton.getInstance();
        instance.fibonacci(x);
	}
	
	public int getHashCode(){
        return instance.hashCode();
    }
}
