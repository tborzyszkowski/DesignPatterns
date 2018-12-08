package Serialization;

import java.io.Serializable;

public class SerializationSingleton  implements Serializable {

    private static SerializationSingleton singleton = new SerializationSingleton();

    private SerializationSingleton() { }

    public static SerializationSingleton getInstance( ) {

        return singleton;
    }

    public Object readResolve() {
        return getInstance( );
    }
}

