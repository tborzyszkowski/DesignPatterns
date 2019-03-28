package test;

import main.SingletonExample;
import org.junit.jupiter.api.AfterAll;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.Test;

import java.io.*;
import java.util.concurrent.*;

import static org.junit.jupiter.api.Assertions.*;

public class SingletonExampleTest {

    @Test
    public void shouldBeTheSameInstance() {
        SingletonExample firstInstance = SingletonExample.getInstance();
        SingletonExample secondInstance = SingletonExample.getInstance();

        assertSame(firstInstance, secondInstance);
    }

    @Test
    public void checkIfSerializedAndDeserializedInstanceAreTheSame() throws IOException, ClassNotFoundException {
        SingletonExample firstInstance = SingletonExample.getInstance();

        serialize(firstInstance);

        firstInstance.setMessage("Message changed");

        SingletonExample secondInstance = deserialize();

        System.out.println("First instance: " + firstInstance.getMessage());
        System.out.println("Second instance: " + secondInstance.getMessage() + "\n");

        assertSame(firstInstance, secondInstance);
    }

    @Test
    public void checkIfSingletonIsThreadSafe() throws InterruptedException, ExecutionException {
        ExecutorService executorService = Executors.newFixedThreadPool(2);

        Callable<SingletonExample> callable = () -> {
            System.out.println("Getting instance inside: " + Thread.currentThread().getName());
            return SingletonExample.getInstance();
        };

        SingletonExample firstInstance = executorService.submit(callable).get();
        SingletonExample secondInstance = executorService.submit(callable).get();

        executorService.shutdown();
        Thread.sleep(100);

        assertSame(firstInstance, secondInstance);
    }

    @AfterEach
    public void cleanInstance() {
        SingletonExample.cleanInstance();
    }

    @AfterAll
    public static void deleteFile() {
        new File("singletonInstance").delete();
    }

    private SingletonExample deserialize() throws IOException, ClassNotFoundException {
        ObjectInput input = new ObjectInputStream(new FileInputStream("singletonInstance"));
        SingletonExample secondInstance = (SingletonExample) input.readObject();
        input.close();
        return secondInstance;
    }

    private void serialize(SingletonExample firstInstance) throws IOException {
        ObjectOutput output = new ObjectOutputStream(new FileOutputStream("singletonInstance"));
        output.writeObject(firstInstance);
        output.close();
    }
}