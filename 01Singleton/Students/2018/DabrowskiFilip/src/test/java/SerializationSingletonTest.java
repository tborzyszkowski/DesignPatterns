import org.junit.Assert;
import org.junit.Test;

import java.io.*;

public class SerializationSingletonTest {

    @Test
    public void check_if_serialized_object_has_the_same_hashcode() throws IOException, ClassNotFoundException {

        SerializationSingleton singleton = SerializationSingleton.getInstance();

        singleton.name = "Pierwszy singleton";
        singleton.age = 1;

        ObjectOutput out = null;

        out = new ObjectOutputStream(new FileOutputStream("singleton.text"));
        out.writeObject(singleton);
        out.close();

        singleton.name = "Drugi Singleton";
        singleton.age = 2;

        ObjectInput in = new ObjectInputStream(new FileInputStream("singleton.text"));
        SerializationSingleton singletonFromFile = (SerializationSingleton) in.readObject();
        in.close();

        System.out.println("singleton hashCode=" + singleton.hashCode());
        System.out.println("singletonFromFile hashCode=" + singletonFromFile.hashCode());

        System.out.println("singleton name = " + singleton.name +", singleton age = " +singleton.age);
        System.out.println("singletonFromFile name = " + singletonFromFile.name +", singletonFromFile age = " +singletonFromFile.age);

        Assert.assertEquals(singleton.hashCode(), singletonFromFile.hashCode());
        Assert.assertEquals(singleton.name, singletonFromFile.name);
        Assert.assertEquals(singleton.age, singletonFromFile.age);

    }
}
