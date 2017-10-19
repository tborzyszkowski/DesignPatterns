package singletonthread;

/**
 *
 * @author pbelke
 */
public class SingletonSync {

    private static SingletonSync instance;

    public static SingletonSync getInstance() {
        if (instance == null) {
            synchronized (SingletonSync.class) {
                if (instance == null) {
                    instance = new SingletonSync();
                }
            }
        }
        return instance;
    }

    private SingletonSync() {
    }
}
