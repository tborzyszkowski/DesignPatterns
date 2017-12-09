package pl.devdiary.wzorce.singleton;

public class DoubleCheckedSingleton {
    private static DoubleCheckedSingleton instance;

    private DoubleCheckedSingleton() {}

    public static DoubleCheckedSingleton getInstance() {
        if(instance == null) {
            synchronized (DoubleCheckedSingleton.class) {
                if(instance == null) {
                    instance = new DoubleCheckedSingleton();
                }
            }
        }

        return instance;
    }
}
