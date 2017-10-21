package singletonreflecton;

/**
 *
 * @author pbelke
 */
public class SingletonException {

    private static SingletonException sSoleInstance;

    public static SingletonException getInstance() {
        if (sSoleInstance == null) {
            sSoleInstance = new SingletonException();
        }

        return sSoleInstance;
    }
    
    private SingletonException() {
        if (sSoleInstance != null) {
            throw new RuntimeException("Use getInstance() method to get the single instance of this class.");
        }
    }
}
