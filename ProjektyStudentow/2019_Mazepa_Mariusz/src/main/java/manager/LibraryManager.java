import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInput;
import java.io.ObjectInputStream;
import java.io.ObjectOutput;
import java.io.ObjectOutputStream;
import java.lang.reflect.Field;

class LibraryManager {
  public static void displayHashCodes(Library instance1, Library instance2) {
      System.out.println("Instance 1: " + instance1.hashCode());
      System.out.println("Instance 2: " + instance2.hashCode());
  }

  public static void displayHashCodes(Library instance1, Library instance2, Library instance3) {
      System.out.println("Instance: " + instance1.hashCode());
      System.out.println("FromFile: " + instance2.hashCode());
      System.out.println("Instance: " + instance3.hashCode());
  }

  public static void resetSingleton(Class theClass, String fieldName) {
    Field instance;
    try {
      instance = theClass.getDeclaredField(fieldName);
      instance.setAccessible(true);
      instance.set(null, null);
      instance.setAccessible(false);
    } catch (Exception e) {
      throw new RuntimeException();
    }
  }

  public static void serialize(Library instance, String filename) throws FileNotFoundException, IOException, ClassNotFoundException {
    ObjectOutput out = new ObjectOutputStream(new FileOutputStream(filename));
    out.writeObject(instance);
    out.close();
  }

  public static Library deserialize(String filename) throws FileNotFoundException, IOException, ClassNotFoundException {
    ObjectInput in = new ObjectInputStream(new FileInputStream(filename));
    Library instance = (Library) in.readObject();
    in.close();
    return instance;
  }
}
