package objectPool;

public class Lock {
    private static Mutex mutex = new Mutex();
    
    public Lock() {
        mutex.acquire();
    }
    
    public void release() {
        mutex.release();
    }    
}
