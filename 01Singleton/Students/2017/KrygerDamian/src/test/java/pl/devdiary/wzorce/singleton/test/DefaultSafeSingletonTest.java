package pl.devdiary.wzorce.singleton.test;

import org.junit.Assert;
import org.junit.Test;
import pl.devdiary.wzorce.singleton.DefaultSafeSingleton;

import java.util.LinkedList;
import java.util.List;
import java.util.concurrent.*;

import static org.hamcrest.CoreMatchers.instanceOf;

public class DefaultSafeSingletonTest {

    public class TestThread implements Callable<DefaultSafeSingleton> {
        @Override
        public DefaultSafeSingleton call() throws Exception {
            return DefaultSafeSingleton.getInstance();
        }
    }

    @Test
    public void ifGetInstanceReturnsSingleton() {
        DefaultSafeSingleton singleton = DefaultSafeSingleton.getInstance();

        Assert.assertThat(singleton, instanceOf(DefaultSafeSingleton.class));
    }

    @Test
    public void ifGetInstanceReturnsOnlyOneInstance() {
        List<Future<DefaultSafeSingleton>> taskList = new LinkedList<>();
        List<DefaultSafeSingleton> list = new LinkedList<>();
        int THREADS_AMOUNT = 1000;

        ExecutorService exec = Executors.newFixedThreadPool(THREADS_AMOUNT);

        long start = System.nanoTime();
        for(int i = 0; i < THREADS_AMOUNT; i++) {
            taskList.add(exec.submit(new TestThread()));
        }

        for (Future<DefaultSafeSingleton> task : taskList) {
            try {
                DefaultSafeSingleton singleton = task.get();

                if(!list.contains(singleton)) list.add(singleton);
            } catch (InterruptedException | ExecutionException e) {
                e.printStackTrace();
            }
        }

        long end = System.nanoTime();
        System.out.println("Default: " + (end - start)/Math.pow(10, 9));

        Assert.assertTrue(list.size() == 1);
    }
}
