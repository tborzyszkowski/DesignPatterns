package pl.devdiary.wzorce.singleton;

import java.io.Serializable;

public class DefaultSafeSingleton implements Serializable {
    private static DefaultSafeSingleton instance;

    private DefaultSafeSingleton() {}

    public static DefaultSafeSingleton getInstance() {
        if(instance == null) {
            instance = new DefaultSafeSingleton();
        }

        return instance;
    }
}
