package singleton;

public class ClassLoadSingleton {

    private static ClassLoadSingleton instance = new ClassLoadSingleton();

    protected ClassLoadSingleton() {
    }

    public static ClassLoadSingleton getInstance() {
        return instance;
    }

}
