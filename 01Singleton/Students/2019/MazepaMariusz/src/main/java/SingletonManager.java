import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInput;
import java.io.ObjectInputStream;
import java.io.ObjectOutput;
import java.io.ObjectOutputStream;

public class SingletonManager {
  public static void mainHeader() {
    System.out.println(" _____ _         _     _             _____         _   ");
    System.out.println("|   __|_|___ ___| |___| |_ ___ ___  |_   _|___ ___| |_ ");
    System.out.println("|__   | |   | . | | -_|  _| . |   |   | | | -_|_ -|  _|");
    System.out.println("|_____|_|_|_|_  |_|___|_| |___|_|_|   |_| |___|___|_|  ");
    System.out.println("            |___|                                      ");
  }

  public static String howManyFrames(String frame, int times) {
    String pattern = frame;
    while (frame.length() < times) frame += pattern;
    return frame;
  }

  public static void testHeader(String testInfo) {
    System.out.print("╔" + howManyFrames("═", testInfo.length() + 2) + "╗\n");
    System.out.println("║ " + testInfo + " ║");
    System.out.print("╚" + howManyFrames("═", testInfo.length() + 2) + "╝\n");
  }

  public static void displayHashCodes(Singleton instance1, Singleton instance2) {
      System.out.println("Instance 1:    " + instance1.hashCode());
      System.out.println("Instance 2:    " + instance2.hashCode());
  }

  public static void serialize(Singleton instance, String filename) throws FileNotFoundException, IOException, ClassNotFoundException {
    ObjectOutput out = new ObjectOutputStream(new FileOutputStream(filename));
    out.writeObject(instance);
    out.close();
  }

  public static Singleton deserialize(String filename) throws FileNotFoundException, IOException, ClassNotFoundException {
    ObjectInput in = new ObjectInputStream(new FileInputStream(filename));
    Singleton instance = (Singleton) in.readObject();
    in.close();
    return instance;
  }
}
