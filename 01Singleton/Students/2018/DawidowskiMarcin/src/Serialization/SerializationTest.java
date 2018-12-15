package Serialization;


import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;

public class SerializationTest {
    static SerializationSingleton singleton = SerializationSingleton.getInstance();
    static SerializationSingleton singleton1  = null;
    static SerializationSingleton singleton2 = null;

    public static void main(String[] args) {
        try {
            FileOutputStream fileOut =
                    new FileOutputStream("singleton.txt");
            ObjectOutputStream out = new ObjectOutputStream(fileOut);
            out.writeObject(singleton);
            out.close();
            fileOut.close();

            FileInputStream fileIn1 = new FileInputStream("singleton.txt");
            FileInputStream fileIn2 = new FileInputStream("singleton.txt");
            ObjectInputStream in1 = new ObjectInputStream(fileIn1);
            ObjectInputStream in2 = new ObjectInputStream(fileIn2);
            singleton1 = (SerializationSingleton) in1.readObject();
            singleton2 = (SerializationSingleton) in2.readObject();
            System.out.println("singleton1 = " + singleton1.hashCode());
            System.out.println("singleton2 = " + singleton2.hashCode());
            in1.close();
            in2.close();
            fileIn1.close();
            fileIn2.close();
        } catch(Exception i) {
            i.printStackTrace();
        }
    }

}
