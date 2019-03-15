package threadsafe;

public class MyThreadOneChecked extends Thread {
	private ThreadSafeSingletonOneChecked instance = null;

	private int x;
	
	public MyThreadOneChecked(int x) {
		this.x = x;
	}
	
	@Override
	public void run() {
        instance = ThreadSafeSingletonOneChecked.getInstance();
        instance.fibonacci(x);
	}
	
	public int getHashCode(){
        return instance.hashCode();
    }
}
