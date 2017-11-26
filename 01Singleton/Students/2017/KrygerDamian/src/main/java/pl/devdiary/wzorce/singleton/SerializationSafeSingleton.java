package pl.devdiary.wzorce.singleton;

import java.io.Serializable;

public class SerializationSafeSingleton implements Serializable {
    private static SerializationSafeSingleton instance;

    private SerializationSafeSingleton() {}

    public static SerializationSafeSingleton getInstance() {
        if(instance == null) {
            instance = new SerializationSafeSingleton();
        }

        return instance;
    }

    protected Object readResolve() {
        return getInstance();
    }
}
