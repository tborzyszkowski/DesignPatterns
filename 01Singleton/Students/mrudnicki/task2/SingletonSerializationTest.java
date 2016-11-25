package task2;

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;

public class SingletonSerializationTest {

    private final static String PATH = "/Users/maciej.rudnicki/smietnik/singleton2.ser";

    private final static String SINGLETON_NAME = "some information";

    private Singleton2 singleton2;

    public static void main(String args[]) {

        SingletonSerializationTest serializer = new SingletonSerializationTest();
        Singleton2 singleton2 = Singleton2.getInstance();
        singleton2.setName(SINGLETON_NAME);

        serializer.serializeSingleton(singleton2);

        serializer.deserializeSingleton();


    }

    public synchronized Singleton2 getSingleton2() {
        if (singleton2 == null) {
            singleton2 = deserializeSingleton();
        }
        return singleton2;
    }


    private void serializeSingleton(Singleton2 singleton2) {
        try {


            FileOutputStream fileOut =
                    new FileOutputStream(PATH);
            ObjectOutputStream out = new ObjectOutputStream(fileOut);
            out.writeObject(singleton2);
            out.close();
            fileOut.close();
            System.out.println("Serialized data is saved ");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }


    public Singleton2 deserializeSingleton() {

        try {
            FileInputStream fileIn = new FileInputStream(PATH);
            ObjectInputStream in = new ObjectInputStream(fileIn);
            Singleton2 singleton2 = (Singleton2) in.readObject();
            in.close();
            fileIn.close();

            return singleton2;
        } catch (IOException | ClassNotFoundException e) {
            throw new RuntimeException("something wrong happened ...");
        }
    }
}

