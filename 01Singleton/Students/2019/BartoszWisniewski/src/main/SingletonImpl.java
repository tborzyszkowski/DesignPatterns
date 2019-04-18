package main;
import java.io.*;

public class SingletonImpl implements Serializable {
    private static SingletonImpl instance;

    private SingletonImpl() { }

    public static SingletonImpl getInstance() {
        if (instance == null) {
            synchronized (SingletonImpl.class) {
                if (instance == null) {
                    instance = new SingletonImpl();
                }
            }	
        }
        return instance;
    }
    //do testów
    public static void cleanInstance() {
        instance = null;
    }

    protected Object readResolve() throws ObjectStreamException {
        return instance;
    }


}