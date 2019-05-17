import org.junit.jupiter.api.Test;

import java.io.*;
import java.util.*;
import java.util.concurrent.Executors;
import java.util.concurrent.ThreadPoolExecutor;

import static org.junit.jupiter.api.Assertions.*;

class SingletonTest {

    @Test
    void basicSingletoneTest() {

        Singleton singleton1 = Singleton.getInstance();
        Singleton singleton2 = Singleton.getInstance();
        System.out.println("Singleton1: " + singleton1.hashCode() + ", Singleton2: " + singleton2.hashCode());
        assertEquals(singleton1.hashCode(), singleton2.hashCode());
    }

    @Test
    void multiThreatsSingletoneTest() {
        int threadsNumber = 300;
        ThreadPoolExecutor executor = (ThreadPoolExecutor) Executors.newFixedThreadPool(threadsNumber);
        List<Singleton> singletons = new ArrayList<>();

        while(executor.getPoolSize() < threadsNumber)
        {
            executor.execute(new Runnable() {
                @Override
                public void run() {
                    Singleton singleton = Singleton.getInstance();
                    singletons.add(singleton);
                }
            });
        }
        executor.shutdown();
        Set<Singleton> singletonPool = new HashSet<>(singletons);
        assertEquals(singletonPool.size(),1);
    }


    @Test
    void serializationSingletoneTest() throws Exception {
        Singleton singleton1 = Singleton.getInstance();
        Singleton singleton2;

        System.out.println(singleton1.getX());
        try (ObjectOutputStream outputStream = new ObjectOutputStream(new FileOutputStream("test"))) {
            outputStream.writeObject(singleton1);
        }

        try (ObjectInputStream inputStream = new ObjectInputStream(new FileInputStream("test"))) {
            singleton2 = (Singleton) inputStream.readObject();
        }

        System.out.println("SingletonSerialized: " + singleton1.hashCode() + ", SingletonDeserialized: " + singleton2.hashCode());
        assertEquals(singleton1.hashCode(),singleton2.hashCode());
    }

    @Test
    void serializationSingletoneVariablesTest(){
        Singleton singleton1 = Singleton.getInstance();
        System.out.println("x:" + singleton1.getX() + " | y:" + singleton1.getY());
        try {
            FileOutputStream fileOut = new FileOutputStream("test2");
            ObjectOutputStream out = new ObjectOutputStream(fileOut);
            out.writeObject(singleton1);
            out.close();
            fileOut.close();
        } catch (IOException i) {
            i.printStackTrace();
        }

        singleton1.setX(7);
        singleton1.setY(7);
        System.out.println("x:" + singleton1.getX() + " | y:" + singleton1.getY());


        try {
            FileInputStream fileIn = new FileInputStream("test2");
            ObjectInputStream in = new ObjectInputStream(fileIn);
            in.readObject();
            in.close();
            fileIn.close();

        } catch (IOException i) {
            i.printStackTrace();
        } catch (ClassNotFoundException c) {
            c.printStackTrace();
        }

        System.out.println("x:" + singleton1.getX() + " | y:" + singleton1.getY());

    }



}