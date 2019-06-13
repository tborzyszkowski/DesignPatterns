import org.junit.Before;
import org.junit.Test;

import java.io.*;
import java.util.*;
import java.util.concurrent.*;

import static org.junit.Assert.*;

public class SingletonTest {

    @Test
    public void singleThreadTest(){

        Singleton instanceOne = Singleton.getInstance();
        Singleton instanceTwo = Singleton.getInstance();

        assertEquals(instanceOne, instanceTwo);

    }

    @Test
    public void isThreadSafe() throws InterruptedException {
        int threadsAmount = 20;
        Set<Singleton> singletonSet = Collections.newSetFromMap(new ConcurrentHashMap<>());

        ExecutorService executor = Executors.newFixedThreadPool(threadsAmount);

        for (int i = 0; i < threadsAmount; i++) {
            executor.execute(() -> {
                Singleton singleton = Singleton.getInstance();
                singletonSet.add(singleton);
            });
        }

        executor.shutdown();
        executor.awaitTermination(1, TimeUnit.MINUTES);

        assertEquals(1, singletonSet.size());
    }


    @Test
    public void serializationTest() throws IOException, ClassNotFoundException {

        Singleton instanceOne = Singleton.getInstance();
        Singleton deserializedInstance;

        ObjectOutput out = new ObjectOutputStream(new FileOutputStream("filename.ser"));
        out.writeObject(instanceOne);
        out.close();

        ObjectInput in = new ObjectInputStream(new FileInputStream("filename.ser"));
        deserializedInstance = (Singleton) in.readObject();
        in.close();

        assertEquals(instanceOne, deserializedInstance);

    }

    @Test
    public void serializationSingletoneVariablesTest() throws IOException, ClassNotFoundException {

        int valueBefore, valueAfter;

        Singleton singletonOne = Singleton.getInstance();

        System.out.println("ValueBefore: " + singletonOne.getValue());
        valueBefore = singletonOne.getValue();

        ObjectOutput out = new ObjectOutputStream(new FileOutputStream("filename.ser"));
        out.writeObject(singletonOne);
        out.close();


        singletonOne.setValue(7);
        System.out.println("ValueSet:" + singletonOne.getValue());


        ObjectInput in = new ObjectInputStream(new FileInputStream("filename.ser"));
        in.readObject();
        in.close();

        System.out.println("ValueAfter: " + singletonOne.getValue());
        valueAfter = singletonOne.getValue();

        assertEquals(valueBefore, valueAfter);


    }



    }