package wisnia;

import static org.junit.Assert.*;

import java.io.*;
import java.util.concurrent.Callable;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;

import org.junit.After;
import org.junit.Test;


public class SingletonTest {
    @After
    public void clean() {
        SingletonImpl.cleanInstance();
    }

    @Test
    public void sameInstanceTest() {
        SingletonImpl lol = SingletonImpl.getInstance();
        // System.out.println(lol);
        SingletonImpl lol2 = SingletonImpl.getInstance();
        // System.out.println(lol2);
        assertEquals(lol, lol2);
    }

    @Test
    public void serializationTest() throws IOException, ClassNotFoundException {
        SingletonImpl lol = SingletonImpl.getInstance();
        ObjectOutput out = new ObjectOutputStream(new FileOutputStream("filename.ser"));
        out.writeObject(lol);
        out.close();

        System.out.println(lol.getWhatever());
        lol.setWhatever("not funny anymore");
        System.out.println(lol.getWhatever());
        ObjectInput in = new ObjectInputStream(new FileInputStream("filename.ser"));
        SingletonImpl lol2 = (SingletonImpl) in.readObject();
        in.close();
        System.out.println(lol.getWhatever());
        System.out.println(lol2.getWhatever());

        assertEquals(lol, lol2);
        // System.out.println(lol);
        // System.out.println(lol2);
    }

    @Test
    public void threadSafeTest() throws InterruptedException, ExecutionException {
        ExecutorService executorOne = Executors.newSingleThreadExecutor();
        Callable<SingletonImpl> callableOne = new Callable<SingletonImpl>() {
            @Override
            public SingletonImpl call() {
                return SingletonImpl.getInstance();
            }
        };
        Future<SingletonImpl> instanceOne = executorOne.submit(callableOne);
        executorOne.shutdown();

        ExecutorService executorTwo = Executors.newSingleThreadExecutor();
        Callable<SingletonImpl> callableTwo = new Callable<SingletonImpl>() {
            @Override
            public SingletonImpl call() {
                return SingletonImpl.getInstance();
            }
        };
        Future<SingletonImpl> instanceTwo = executorTwo.submit(callableTwo);
        executorTwo.shutdown();

        assertEquals(instanceOne.get(), instanceTwo.get());
    }

}