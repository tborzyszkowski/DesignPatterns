import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInput;
import java.io.ObjectInputStream;
import java.io.ObjectOutput;
import java.io.ObjectOutputStream;

class SingletonTest3 {
  public static String filename = "instance.ser";

  public static Singleton createAndSerialize() throws FileNotFoundException, IOException, ClassNotFoundException {
    Singleton instance = Singleton.getInstance();
    ObjectOutput out = new ObjectOutputStream(new FileOutputStream(filename));
    out.writeObject(instance);
    out.close();
    return instance;
  }

  public static Singleton deserialize() throws FileNotFoundException, IOException, ClassNotFoundException {
    ObjectInput in = new ObjectInputStream(new FileInputStream(filename));
    Singleton instance = (Singleton) in.readObject();
    in.close();
    return instance;
  }

  public static void main(String[] args) throws FileNotFoundException, IOException, ClassNotFoundException {
    Singleton instance1 = createAndSerialize();
    Singleton instance2 = deserialize();
    Helper.compareInstances(instance1, instance2);
  }
}
