package singletonreflecton;

/**
 *
 * @author Piotrek
 */
public class Singleton {

    private static Singleton sSoleInstance;

    public static Singleton getInstance() {
        if (sSoleInstance == null) {
            sSoleInstance = new Singleton();
        }

        return sSoleInstance;
    }

    private Singleton() {
    }
}
