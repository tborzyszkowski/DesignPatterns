package main;

import java.io.*;

public class SingletonExample implements Serializable {
    private static SingletonExample instance;
    private String message = "Message";

    private SingletonExample() { }

    public static SingletonExample getInstance() {
        if (instance == null) {
            synchronized (SingletonExample.class) {
                if (instance == null) {
                    instance = new SingletonExample();
                }
            }
        }
        return instance;
    }

    public static void cleanInstance() {
        instance = null;
    }

    protected Object readResolve() throws ObjectStreamException {
        if (instance == null)
            instance = this;
        instance.setMessage(this.getMessage());
        return instance;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }
}

