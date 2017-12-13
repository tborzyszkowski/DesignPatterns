package pl.devdiary.wzorce.singleton.test;

import org.junit.Assert;
import org.junit.Test;
import pl.devdiary.wzorce.singleton.DoubleCheckedSingleton;

import java.util.LinkedList;
import java.util.List;
import java.util.concurrent.*;

import static org.hamcrest.CoreMatchers.instanceOf;

public class DoubleCheckedSingletonTest {

    public class TestThread implements Callable<DoubleCheckedSingleton> {
        @Override
        public DoubleCheckedSingleton call() throws Exception {
            return DoubleCheckedSingleton.getInstance();
        }
    }

    @Test
    public void ifGetInstanceReturnsSingleton() {
        DoubleCheckedSingleton singleton = DoubleCheckedSingleton.getInstance();

        Assert.assertThat(singleton, instanceOf(DoubleCheckedSingleton.class));
    }

    @Test
    public void ifGetInstanceReturnsOnlyOneInstance() {
        List<Future<DoubleCheckedSingleton>> taskList = new LinkedList<>();
        List<DoubleCheckedSingleton> list = new LinkedList<>();
        int THREADS_AMOUNT = 1000;

        ExecutorService exec = Executors.newFixedThreadPool(THREADS_AMOUNT);

        long start = System.nanoTime();
        for(int i = 0; i < THREADS_AMOUNT; i++) {
            taskList.add(exec.submit(new DoubleCheckedSingletonTest.TestThread()));
        }

        for (Future<DoubleCheckedSingleton> task : taskList) {
            try {
                DoubleCheckedSingleton singleton = task.get();

                if(!list.contains(singleton)) list.add(singleton);
            } catch (InterruptedException | ExecutionException e) {
                e.printStackTrace();
            }
        }

        long end = System.nanoTime();
        System.out.println("Double checked: " + (end - start)/Math.pow(10, 9));

        Assert.assertTrue(list.size() == 1);
    }
}
