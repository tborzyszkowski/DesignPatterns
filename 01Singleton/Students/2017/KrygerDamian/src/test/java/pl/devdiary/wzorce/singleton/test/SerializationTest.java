package pl.devdiary.wzorce.singleton.test;

import org.junit.Assert;
import org.junit.Test;
import pl.devdiary.wzorce.singleton.DefaultSafeSingleton;
import pl.devdiary.wzorce.singleton.SerializationSafeSingleton;

import java.io.*;

public class SerializationTest {

    @Test
    public void serializeDefaultSingleton() throws IOException, ClassNotFoundException {
        // serialization
        DefaultSafeSingleton instanceOne = DefaultSafeSingleton.getInstance();
        ObjectOutput out = new ObjectOutputStream(new FileOutputStream("singleton.ser"));
        out.writeObject(instanceOne);
        out.close();

        // deserialization
        ObjectInput in = new ObjectInputStream(new FileInputStream("singleton.ser"));
        DefaultSafeSingleton instanceTwo = (DefaultSafeSingleton) in.readObject();
        in.close();

        Assert.assertNotEquals(instanceOne.hashCode(), instanceTwo.hashCode());
    }

    @Test
    public void serializeSerializationSafeSingleton() throws IOException, ClassNotFoundException {
        // serialization
        SerializationSafeSingleton instanceOne = SerializationSafeSingleton.getInstance();
        ObjectOutput out = new ObjectOutputStream(new FileOutputStream("singleton1.ser"));
        out.writeObject(instanceOne);
        out.close();

        // deserialization
        ObjectInput in = new ObjectInputStream(new FileInputStream("singleton1.ser"));
        SerializationSafeSingleton instanceTwo = (SerializationSafeSingleton) in.readObject();
        in.close();

        Assert.assertEquals(instanceOne.hashCode(), instanceTwo.hashCode());
    }
}
