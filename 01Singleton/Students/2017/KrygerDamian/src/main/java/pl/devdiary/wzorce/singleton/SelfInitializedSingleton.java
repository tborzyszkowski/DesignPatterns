package pl.devdiary.wzorce.singleton;

public class SelfInitializedSingleton {
    private static SelfInitializedSingleton instance = new SelfInitializedSingleton();

    private SelfInitializedSingleton() {}

    public static SelfInitializedSingleton getInstance() {
        return instance;
    }
}
