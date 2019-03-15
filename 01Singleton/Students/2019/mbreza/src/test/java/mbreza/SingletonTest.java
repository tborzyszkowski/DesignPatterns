package mbreza;

import static org.junit.Assert.*;

import org.junit.Test;

import java.io.*;
import java.util.concurrent.*;


public class SingletonTest {

    @Test
    public void basicSingletonTest(){
        Singleton instanceOne = Singleton.getInstance("");
        Singleton instanceTwo = Singleton.getInstance("");

        assertEquals(instanceOne, instanceTwo);

        instanceOne.cleanUp();
    }

    @Test
    public void serializableSingletonTest() throws IOException, ClassNotFoundException {
        Singleton instance = Singleton.getInstance("");

        ObjectOutput out = new ObjectOutputStream(new FileOutputStream("filename.ser"));
        out.writeObject(instance);
        out.close();

        ObjectInput in = new ObjectInputStream(new FileInputStream("filename.ser"));
        Singleton deserializedInstance = (Singleton) in.readObject();
        in.close();

        assertEquals(instance, deserializedInstance);

        instance.cleanUp();
    }

    @Test
    public void threadSingletonTest() throws ExecutionException, InterruptedException {
        ExecutorService executorOne = Executors.newSingleThreadExecutor();
        Callable<Singleton> callableOne = new Callable<Singleton>() {
            @Override
            public Singleton call() {
                return Singleton.getInstance("");
            }
        };
        Future<Singleton> instanceOne = executorOne.submit(callableOne);
        executorOne.shutdown();

        ExecutorService executorTwo = Executors.newSingleThreadExecutor();
        Callable<Singleton> callableTwo = new Callable<Singleton>() {
            @Override
            public Singleton call() {
                return Singleton.getInstance("");
            }
        };
        Future<Singleton> instanceTwo = executorTwo.submit(callableTwo);
        executorTwo.shutdown();

        assertEquals(instanceOne.get(), instanceTwo.get());

        instanceOne.get().cleanUp();
    }

    @Test
    public void inheritanceSingleton(){
        Singleton instanceOne = Singleton.getInstance("");
        Singleton instanceTwo = Singleton.getInstance("One");
        Singleton instanceThree = Singleton.getInstance("Two");

        assertEquals(instanceOne, instanceTwo);
        assertEquals(instanceOne, instanceThree);
        assertEquals("Nothing", instanceOne.writeSomething());
        assertEquals("Nothing", instanceTwo.writeSomething());
        assertEquals("Nothing", instanceThree.writeSomething());

        instanceOne.cleanUp();
    }

    @Test
    public void inheritanceSingletonOne() throws InterruptedException {
        Singleton instanceOne = Singleton.getInstance("One");
        Singleton instanceTwo = Singleton.getInstance("");
        Singleton instanceThree = Singleton.getInstance("Two");

        System.out.println(instanceOne);

        assertEquals(instanceOne, instanceTwo);
        assertEquals(instanceOne, instanceThree);
        assertEquals("One", instanceOne.writeSomething());
        assertEquals("One", instanceTwo.writeSomething());
        assertEquals("One", instanceThree.writeSomething());

        instanceOne.cleanUp();
    }

    @Test
    public void inheritanceSingletonTwo() throws InterruptedException {
        Singleton instanceOne = Singleton.getInstance("Two");
        Singleton instanceTwo = Singleton.getInstance("");
        Singleton instanceThree = Singleton.getInstance("One");

        System.out.println(instanceOne);

        assertEquals(instanceOne, instanceTwo);
        assertEquals(instanceOne, instanceThree);
        assertEquals("Two", instanceOne.writeSomething());
        assertEquals("Two", instanceTwo.writeSomething());
        assertEquals("Two", instanceThree.writeSomething());

        instanceOne.cleanUp();
    }
}
