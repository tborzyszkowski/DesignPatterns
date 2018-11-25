import java.io.Serializable;

public class SerializationSingleton implements Serializable {

    private static SerializationSingleton singletonInstance;

    public String name;

    public int age;

    public static SerializationSingleton getInstance() {
        if (singletonInstance == null) {
            // double checked locking
            synchronized (SerializationSingleton.class) {
                if(singletonInstance == null){
                    singletonInstance = new SerializationSingleton();
                }
            }
        }
        return singletonInstance;
    }

    protected Object readResolve() {
        return singletonInstance;
    }

    @Override
    public int hashCode() {
        return super.hashCode();
    }

    @Override
    public boolean equals(Object obj) {
        return super.equals(obj);
    }

}
