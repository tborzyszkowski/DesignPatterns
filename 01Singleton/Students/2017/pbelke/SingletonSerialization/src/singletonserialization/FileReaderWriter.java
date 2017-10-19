package singletonserialization;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInput;
import java.io.ObjectInputStream;
import java.io.ObjectOutput;
import java.io.ObjectOutputStream;

/**
 *
 * @author pbelke
 */
public class FileReaderWriter {

    public static void write(Object instance) throws FileNotFoundException, IOException {
        ObjectOutput out = new ObjectOutputStream(new FileOutputStream("singleton.ser"));
        out.writeObject(instance);
        out.close();
    }

    public static Object read() throws FileNotFoundException, ClassNotFoundException, IOException {
        ObjectInput in = new ObjectInputStream(new FileInputStream("singleton.ser"));
        Singleton instanceTwo = (Singleton) in.readObject();
        in.close();
        return instanceTwo;
    }
}
