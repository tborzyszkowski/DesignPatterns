package pl.devdiary.wzorce.singleton.test;

import org.junit.Assert;
import org.junit.Test;
import pl.devdiary.wzorce.singleton.SynchronizedSingleton;

import java.util.LinkedList;
import java.util.List;
import java.util.concurrent.*;

import static org.hamcrest.CoreMatchers.instanceOf;

public class SynchronizedSingletonTest {

    public class TestThread implements Callable<SynchronizedSingleton> {
        @Override
        public SynchronizedSingleton call() throws Exception {
            return SynchronizedSingleton.getInstance();
        }
    }

    @Test
    public void ifGetInstanceReturnsSingleton() {
        SynchronizedSingleton singleton = SynchronizedSingleton.getInstance();

        Assert.assertThat(singleton, instanceOf(SynchronizedSingleton.class));
    }

    @Test
    public void ifGetInstanceReturnsOnlyOneInstance() {
        List<Future<SynchronizedSingleton>> taskList = new LinkedList<>();
        List<SynchronizedSingleton> list = new LinkedList<>();
        int THREADS_AMOUNT = 1000;

        ExecutorService exec = Executors.newFixedThreadPool(THREADS_AMOUNT);

        long start = System.nanoTime();
        for(int i = 0; i < THREADS_AMOUNT; i++) {
            taskList.add(exec.submit(new SynchronizedSingletonTest.TestThread()));
        }

        for (Future<SynchronizedSingleton> task : taskList) {
            try {
                SynchronizedSingleton singleton = task.get();

                if(!list.contains(singleton)) list.add(singleton);
            } catch (InterruptedException | ExecutionException e) {
                e.printStackTrace();
            }
        }

        long end = System.nanoTime();
        System.out.println("Synchronized: " + (end - start)/Math.pow(10, 9));

        Assert.assertTrue(list.size() == 1);
    }
}
