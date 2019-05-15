package wisnia;

import java.io.*;

public class SingletonImpl implements Serializable {
    private static SingletonImpl instance;
    private String whatever = "lol";

    public String getWhatever() {
        return whatever;
    }

    public void setWhatever(String whatever) {
        this.whatever = whatever;
    }

    private SingletonImpl() {
    }

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

    // do testów
    public static void cleanInstance() {

        instance = null;
    }

    protected Object readResolve() throws ObjectStreamException {
        if (instance == null)
            instance = this;
        instance.setWhatever(this.whatever);
        return instance;
    }

}