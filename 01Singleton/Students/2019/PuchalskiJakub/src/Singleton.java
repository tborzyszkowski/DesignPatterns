import java.io.ObjectStreamException;
import java.io.Serializable;

public class Singleton implements Serializable {

    private static Singleton instance;
    private int value = 10;

    private Singleton() {}

    public static Singleton getInstance() {
        if (instance == null) {
            synchronized (Singleton.class) {
                if (instance == null) {
                    instance = new Singleton();
                }
            }
        }
        return instance;
    }

    public int getValue() {
        return value;
    }

    public void setValue(int newValue) {
        value = newValue;
    }

    protected Object readResolve() throws ObjectStreamException {

        instance.value = this.value;
        return getInstance();

    }


}
