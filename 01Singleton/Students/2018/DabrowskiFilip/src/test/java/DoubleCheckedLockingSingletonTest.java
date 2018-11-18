import org.junit.Assert;
import org.junit.Test;

import java.io.*;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Set;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;

public class DoubleCheckedLockingSingletonTest {

    @Test
    public void check_if_multitreading_problem_is_solved_by_using_double_checked_locking() throws InterruptedException {

        int threadsAmount = 500;
        Set<DoubleCheckedLockingSingleton> singletonSet =  Collections.newSetFromMap(new ConcurrentHashMap<>());
        ExecutorService executorService = Executors.newFixedThreadPool(threadsAmount);

        for (int i = 0; i < threadsAmount; i++) {
            executorService.execute(() -> {
                DoubleCheckedLockingSingleton singleton = DoubleCheckedLockingSingleton.getInstance();
                singletonSet.add(singleton);
            });
        }

        executorService.shutdown();
        executorService.awaitTermination(1, TimeUnit.MINUTES);

        System.out.println(singletonSet);

        Assert.assertEquals(1, singletonSet.size());

    }

    @Test
    public void check_if_serialized_object_has_different_hashcode() throws IOException, ClassNotFoundException {
        DoubleCheckedLockingSingleton singleton = DoubleCheckedLockingSingleton.getInstance();

        ObjectOutput out = null;

        out = new ObjectOutputStream(new FileOutputStream("doubleCheckedLockingSingleton.ser"));
        out.writeObject(singleton);
        out.close();

        ObjectInput in = new ObjectInputStream(new FileInputStream("doubleCheckedLockingSingleton.ser"));
        DoubleCheckedLockingSingleton singletonFromFile = (DoubleCheckedLockingSingleton) in.readObject();
        in.close();

        System.out.println("singleton hashCode=" + singleton.hashCode());
        System.out.println("singletonFromFile hashCode=" + singletonFromFile.hashCode());

        Assert.assertNotEquals(singleton.hashCode(), singletonFromFile.hashCode());

    }

}
