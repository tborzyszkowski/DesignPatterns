package pl.devdiary.wzorce.singleton.test;

import org.junit.Assert;
import org.junit.Test;
import pl.devdiary.wzorce.singleton.SelfInitializedSingleton;

import java.util.LinkedList;
import java.util.List;
import java.util.concurrent.*;

import static org.hamcrest.CoreMatchers.instanceOf;

public class SelfInitializedSingletonTest {

    public class TestThread implements Callable<SelfInitializedSingleton> {
        @Override
        public SelfInitializedSingleton call() throws Exception {
            return SelfInitializedSingleton.getInstance();
        }
    }

    @Test
    public void ifGetInstanceReturnsSingleton() {
        SelfInitializedSingleton singleton = SelfInitializedSingleton.getInstance();

        Assert.assertThat(singleton, instanceOf(SelfInitializedSingleton.class));
    }

    @Test
    public void ifGetInstanceReturnsOnlyOneInstance() {
        List<Future<SelfInitializedSingleton>> taskList = new LinkedList<>();
        List<SelfInitializedSingleton> list = new LinkedList<>();
        int THREADS_AMOUNT = 1000;

        ExecutorService exec = Executors.newFixedThreadPool(THREADS_AMOUNT);

        long start = System.nanoTime();
        for(int i = 0; i < THREADS_AMOUNT; i++) {
            taskList.add(exec.submit(new SelfInitializedSingletonTest.TestThread()));
        }

        for (Future<SelfInitializedSingleton> task : taskList) {
            try {
                SelfInitializedSingleton singleton = task.get();

                if(!list.contains(singleton)) list.add(singleton);
            } catch (InterruptedException | ExecutionException e) {
                e.printStackTrace();
            }
        }

        long end = System.nanoTime();
        System.out.println("Self initialized: " + (end - start)/Math.pow(10, 9));

        Assert.assertTrue(list.size() == 1);
    }
}
