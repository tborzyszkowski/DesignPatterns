package objectPool;

public class Mutex {
	static private java.util.concurrent.locks.Lock
            reentrantLock =
            new java.util.concurrent.locks.ReentrantLock();
    
    public void acquire() {
        reentrantLock.lock();
    }
    
    public void release() {
        reentrantLock.unlock();
    }    
}
