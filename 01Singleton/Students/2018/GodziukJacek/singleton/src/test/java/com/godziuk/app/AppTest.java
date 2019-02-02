package com.godziuk.app;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.ObjectInput;
import java.io.ObjectInputStream;
import java.io.ObjectOutput;
import java.io.ObjectOutputStream;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Set;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;
import org.junit.Assert;
import org.junit.Test;


public class AppTest {

    //--------------------------------classic singleton--------------------------------
    @Test
    public void test1()
    {
        System.out.println("\n SingletonClassic test 1:");
        SingletonClassic s1 = SingletonClassic.getInstance();
        SingletonClassic s2 = SingletonClassic.getInstance();
        
        s1.name = "Jan";
        s2.name = "Anna";
        
        System.out.println(s1.name);
        System.out.println(s2.name);
    }
    
    @Test
    public void test2() throws InterruptedException
    {
        System.out.println("\n SingletonClassic test 2:");
        final List<SingletonClassic> list = new ArrayList<>();
        ExecutorService executorService = Executors.newFixedThreadPool(3);
        
        executorService.execute(new Runnable() { 
            public void run() { 
                SingletonClassic singleton = SingletonClassic.getInstance();
                list.add(singleton);
            } 
        });
        
        executorService.execute(new Runnable() { 
            public void run() { 
                SingletonClassic singleton = SingletonClassic.getInstance();
                list.add(singleton);
            } 
        });
        
        executorService.execute(new Runnable() { 
            public void run() { 
                SingletonClassic singleton = SingletonClassic.getInstance();
                list.add(singleton);
            } 
        });
        
        executorService.shutdown();
        executorService.awaitTermination(1, TimeUnit.MINUTES);
        
        for(SingletonClassic s : list){
            System.out.println(s.name);
        }
    }
    
    //--------------------------------double check lock singleton--------------------------------
    @Test
    public void test3() throws InterruptedException{
        System.out.println("\n SingletonDoubleCheckLocking test 1:");
        int threadsAmount = 500;
        final List<SingletonDCL> singletonsList = new ArrayList<>();
        ExecutorService executorService = Executors.newFixedThreadPool(threadsAmount);

        for (int i = 0; i < threadsAmount; i++) {
            executorService.execute(new Runnable() {
                public void run() {
                    SingletonDCL singleton = SingletonDCL.getInstance();
                    singletonsList.add(singleton);
                }
            });
        }

        executorService.shutdown();
        executorService.awaitTermination(1, TimeUnit.MINUTES);

        System.out.println("Ilosc instancji: " + singletonsList.size());

    }
    
    //--------------------------------serialization singleton--------------------------------
    
    @Test
    public void test4() throws FileNotFoundException, IOException, ClassNotFoundException {
        System.out.println("\n SingletonSerialization test 1:");
        SingletonSerialization instanceOne = SingletonSerialization.getInstance();
        // Serialize to a file
            ObjectOutput out = new ObjectOutputStream(new FileOutputStream(
                    "filename.ser"));
            out.writeObject(instanceOne);
            out.close();
 
            instanceOne.name = "Jacek";
 
            // Serialize to a file
            ObjectInput in = new ObjectInputStream(new FileInputStream(
                    "filename.ser"));
            SingletonSerialization instanceTwo = (SingletonSerialization) in.readObject();
            in.close();
 
            System.out.println(instanceOne.name);
            System.out.println(instanceTwo.name);

    }
}
